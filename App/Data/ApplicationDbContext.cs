using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using App.Data;
using App.Data.Party;

namespace App.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<StudentData> Students { get; set; }
    public DbSet<InstructorData> Instructors { get; set; }
    public DbSet<LessonData> Lessons { get; set; }
}