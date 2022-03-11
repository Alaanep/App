﻿using System;
using System.Collections.Generic;
using System.Reflection;
using App.Aids;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests
{
    public class IsTypeTested : TestAsserts {
        private string? nameOfTest;
        private string? nameOfType;
        private string? namespaceOfTest;
        private string? namespaceOfType;
        private Assembly? assemblyToBeTested;
        private Type? typesToBeTested;
        private List<string>? membersOfType;
        private List<string>? membersOfTest;
        [TestMethod] public void IsAllTested() => isAllTested();

        protected virtual void isAllTested() {
            nameOfTest = getName(this);
            nameOfType = removeTestsTagFrom(nameOfTest);
            namespaceOfTest = getNamespace(this);
            namespaceOfType = removeTestsTagFrom(namespaceOfTest);
            assemblyToBeTested = getAssembly(namespaceOfType);
            typesToBeTested = getType(assemblyToBeTested, nameOfType);
            membersOfType = getMembers(typesToBeTested);
            membersOfTest = getMembers(GetType());
            removeNotTests(GetType());
            removeNotNeedTesting();
            removeTested();
            if (allAreTested()) return;
            reportNotAllIsTested();
        }

        private static string? getName(object o) => Types.GetName(o?.GetType());
        private static string? removeTestsTagFrom(string? nameOfTests) =>
            nameOfTests?.Remove("Tests")?.Remove("Test")?.Replace("..", ".");
        private static string? getNamespace(object o) => GetNameSpace.OfType(o);

        private static Assembly? getAssembly(string? name) {
            while (!string.IsNullOrWhiteSpace(name)) {
                var a = GetAssembly.ByName(name);
                if (a is not null) return a;
                name = name.RemoveTail();
            }
            return null;
        }
        private static Type? getType(Assembly? a, string? name) {
            if (string.IsNullOrWhiteSpace(name)) return null;
            foreach (var t in a?.DefinedTypes ?? Array.Empty<TypeInfo>()) 
                if (t.Name.StartsWith(name)) return t.AsType();
            return null;
        } 
        private static List<string>? getMembers(Type? t) => t?.DeclaredMembers();
        private void removeNotTests(Type t) => membersOfTest?.Remove(x => !isCorrectTestMethod(x, t));
        private static bool isCorrectTestMethod(string x, Type t) =>
            isCorrectlyInherited(t) && isTestClass(t) && isTestMethod(x, t);
        private static bool isTestClass(Type x) => x?.HasAttribute<TestClassAttribute>() ?? false;
        private static bool isTestMethod(string methodName, Type t) =>
            t?.Method(methodName).HasAttribute<TestMethodAttribute>() ?? false;
        private static bool isCorrectlyInherited(Type x) => x.IsInherited(typeof(IsTypeTested));
        private void removeNotNeedTesting() => membersOfType?.Remove(x => !isTypeToBeTested(x));
        private static bool isTypeToBeTested(string x) => x?.IsTypeName() ?? false;
        private void removeTested() => membersOfType?.Remove(x => isItTested(x));
        private bool isItTested(string x) => membersOfTest?.ContainsItem(y => isTestFor(y, x)) ?? false;
        private static bool isTestFor(string testingMember, string memberToBeTested) =>
            testingMember.Equals(memberToBeTested + "Test");
        private bool allAreTested() => membersOfType.IsEmpty();
        private void reportNotAllIsTested() => isInconclusive($"Member \"{nameOfFirstNotTested()}\" is not tested");

        private string nameOfFirstNotTested() => membersOfType?.GetFirst() ?? string.Empty;

    }
}
