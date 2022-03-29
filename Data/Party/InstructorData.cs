namespace App.Data.Party {
    public sealed class InstructorData: UniqueData {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? PhoneNr { get; set; }
        public string? LessonsGiven { get; set; }
    }
}
