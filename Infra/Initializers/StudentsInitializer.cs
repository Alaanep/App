using App.Data.Party;

namespace App.Infra.Initializers {
    public sealed class StudentsInitializer : BaseInitializer<StudentData> {
        public StudentsInitializer(AppDB? db) : base(db, db?.Students) { }

        protected override IEnumerable<StudentData> getEntities => new StudentData[] {
            greateStudent("Malle", "Kask", "53456789", "mallekalle@mail.com", "65", "175", "39", new DateTime(1985,05,05),"B1" ),
            greateStudent("Kalle", "Tamm", "54456789", "kalletamm@mail.com", "75", "176", "42", new DateTime(1986,06,06),"B1"),
            greateStudent("Tauno", "Vaher", "55456789", "taunovaher@mail.com", "76", "177", "43", new DateTime(1987,07,07),"B1"),
            greateStudent("Helle", "Hell", "56456789", "hellehell@mail.com", "78", "178", "44", new DateTime(1988,08,08),"B1")
        };

        internal static StudentData greateStudent(string firstName,
            string lastName,
            string phoneNr,
            string email,
            string weight,
            string height,
            string shoeSize,
            DateTime enrollmentDate,
            string level) {
            var student = 
                new StudentData() {
                Id = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = lastName,
                PhoneNr = phoneNr,
                Email = email,
                Weight = weight,
                Height = height,
                ShoeSize = shoeSize,
                EnrollmentDate = enrollmentDate,
                Level = level
            };
            return student;
        }
    }
}
