using App.Data.Party;

namespace App.Infra.Initializers {
    public sealed class InstructorsInitializer : BaseInitializer<InstructorData> {

        public InstructorsInitializer(AppDB? db) : base(db, db?.Instructors) { }

        protected override IEnumerable<InstructorData> getEntities => new InstructorData[] {
            createInstructor("Toomas", "Toob", "51543765", "3"),
            createInstructor("Madis", "Viib", "52543765", "4"),
            createInstructor("Maru", "Vahva",  "53543765", "5")
        };

        internal static InstructorData createInstructor(string firstName, string lastName, string phoneNr, string lessonsGiven) {
            var instructor = new InstructorData() {
                Id = Guid.NewGuid().ToString(),
                FirstName = firstName,
                LastName = lastName,
                PhoneNr = phoneNr,
                LessonsGiven = lessonsGiven
            };
            return instructor;
        }
    }
}
