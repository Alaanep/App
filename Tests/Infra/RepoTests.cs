﻿using App.Data.Party;
using App.Domain.Party;
using App.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace App.Tests.Infra
{
    [TestClass]
    public class RepoTests : AbstractClassTests
    {
        private class testClass : Repo<Instructor, InstructorData>
        {
            public testClass(DbContext? c, DbSet<InstructorData>? s) : base(c, s) { }

            protected override Instructor toDomain(InstructorData d) => new(d);
        }
        protected override object createObj() => new testClass(null, null);
    }
}