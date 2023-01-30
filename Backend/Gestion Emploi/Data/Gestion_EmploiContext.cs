using Gestion_Emploi.Models;
using Microsoft.EntityFrameworkCore;

namespace Gestion_Emploi.Data
{
    public class Gestion_EmploiContext : DbContext
    {
        public Gestion_EmploiContext(DbContextOptions<Gestion_EmploiContext> options) : base(options) { }

        public DbSet<Student> Student { get; set; } = default!;

        public DbSet<Classroom> Classroom { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Classmate> Classmate { get; set; }

        public DbSet<Lesson> Lesson { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<Gestion_Emploi.Models.Schedule> Schedule { get; set; }
    }
}
