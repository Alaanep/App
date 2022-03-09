﻿using App.Data.Party;
namespace App.Domain.Party {
    public class Student: Entity<StudentData> {
        public Student(): this(new StudentData()){ }
        public Student(StudentData d): base(d){}
        public string FirstName => getValue(Data?.FirstName);
        public string LastName => getValue(Data?.LastName);
        public string PhoneNr => getValue(Data?.PhoneNr);
        public string Email => getValue(Data?.Email);
        public string Weight => getValue(Data?.Weight);
        public string Height => getValue(Data?.Height);
        public string ShoeSize => getValue(Data?.ShoeSize);
        public DateTime EnrollmentDate => getValue(Data?.EnrollmentDate);
        public string Level => getValue(Data?.Level);
        public override string ToString() => $"{FirstName} {LastName}";
    }
}
