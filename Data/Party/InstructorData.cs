namespace App.Data.Party {
    public sealed class InstructorData: EntityData {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNr { get; set; }
        public string? LessonsGiven { get; set; }
    }
}
