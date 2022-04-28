﻿using App.Aids;
using App.Data.Party;
using App.Domain.Party;
using App.Facade.Party;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Pages.Party
{
    public class LessonsPage: PagedPage<LessonView, Lesson, ILessonsRepo>
    {
        private readonly IStudentsRepo students;

        public LessonsPage(ILessonsRepo r, IStudentsRepo s) : base(r) {
            students = s;
        }
        protected override Lesson toObject(LessonView? item) => new LessonViewFactory().Create(item);
        protected override LessonView toView(Lesson? entity) => new LessonViewFactory().Create(entity);
        public override string[] IndexColumns { get; } = new[] {
            nameof(LessonView.Instructor),
            nameof(LessonView.Student),
            nameof(LessonView.LessonName),
            nameof(LessonView.LessonTime),
            nameof(LessonView.Location),
            nameof(LessonView.EquipmentNeeded),
        };

        public IEnumerable<SelectListItem> Students
            => students?.GetAll(x => x.ToString())?
                   .Select(x => new SelectListItem(x.ToString(), x.Id))
               ?? new List<SelectListItem>();

        public string StudentName(string? countryId = null)
            => Students?.FirstOrDefault(x => x.Value == countryId)?.Text ?? "Unspecified";

        public override object? GetValue(string name, LessonView v) {
            var result = base.GetValue(name, v);
            return name == nameof(LessonView.Student) ? StudentName(result as string) : result;
        }


        public IEnumerable<SelectListItem> Levels
            => Enum.GetValues<Level>()?
                   .Select(x => new SelectListItem(x.Description(), x.ToString()))
               ?? new List<SelectListItem>();

        public string LevelDescription(Level? isoGender)
            => (isoGender ?? Level.NotKnown).Description();

        public  object? GetLessonValue(string name, LessonView v) {
            var result = base.GetValue(name, v);
            return name == nameof(LessonView.LessonName) ? LevelDescription((Level)result) : result;
        }
    }
}
