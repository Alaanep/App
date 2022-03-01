
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace App.Facade.Party;

public class LessonView
{
    [Required] public string Id { get; set; }
    [DisplayName("Instructor")]public  string? Instructor { get; set; }
    [DisplayName("Student")] public string? Student { get; set; }
    [DisplayName("Lesson: ")] public string? LessonName { get; set; }
    [DisplayName("Lesson Time")] public DateTime? LessonTime { get; set; }
    [DisplayName("Location")] public string? Location { get; set; }
    [DisplayName("Equipment needed: ")] public string? EquipmentNeeded { get; set; }
    [DisplayName("Lesson")] public string? FullName { get; set; }
}