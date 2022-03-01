
using App.Data.Party;
using App.Domain.Party;

namespace App.Facade.Party;

public class LessonViewFactory
{
    public Lesson Create(LessonView v) => new Lesson(new LessonData
    {
        Id = v.Id,
        Instructor = v.Instructor,
        Student = v.Student,
        LessonName = v.LessonName,
        LessonTime = v.LessonTime,
        Location = v.Location,
        EquipmentNeeded = v.EquipmentNeeded,
    });

    public LessonView Create(Lesson lesson) => new LessonView
    {   
        Id = lesson.Id,
        Instructor = lesson.Instructor,
        Student = lesson.Student,
        LessonName = lesson.LessonName,
        LessonTime = lesson.LessonTime,
        Location = lesson.Location,
        EquipmentNeeded = lesson.EquipmentNeeded,
        FullName = lesson.ToString()
    };
}