namespace App.Data.Party {
    public sealed class LessonData: EntityData {
        public string? Instructor { get; set; }
        public string? Student { get; set; }
        public string? LessonName { get; set; }
        public DateTime? LessonTime { get; set; }
        public string? Location { get; set; }
        public string? EquipmentNeeded { get; set; }
    }
}
