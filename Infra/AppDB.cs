﻿using App.Data.Party;
using Microsoft.EntityFrameworkCore;

namespace App.Infra {
    public sealed class AppDB: DbContext {
        public AppDB(DbContextOptions<AppDB> options) : base(options) { }
        public DbSet<StudentData>? Students { get; set; }
        public DbSet<InstructorData>? Instructors { get; set; }
        public DbSet<LessonData>? Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
            InitializeTables(modelBuilder);
        }

        public static void InitializeTables(ModelBuilder modelBuilder) {
            _= (modelBuilder?.Entity<StudentData>()?.ToTable(nameof(Students), nameof(AppDB)));
            _= (modelBuilder?.Entity<InstructorData>()?.ToTable(nameof(Instructors), nameof(AppDB)));
            _= (modelBuilder?.Entity<LessonData>()?.ToTable(nameof(Lessons), nameof(AppDB)));
        }
    }
}
