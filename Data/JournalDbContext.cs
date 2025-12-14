using Microsoft.EntityFrameworkCore;
using AcademicJournal.Models;

namespace AcademicJournal.Data
{
    public class JournalDbContext : DbContext
    {
        public JournalDbContext(DbContextOptions<JournalDbContext> options)
            : base(options)
        {
        }

        // Наши таблицы
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Grade> Grades { get; set; }

        // Заполнение начальными данными при создании БД
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Иван Иванов" },
                new Student { Id = 2, Name = "Петр Петров" },
                new Student { Id = 3, Name = "Мария Сидорова" }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = 1, Title = "Математика" },
                new Course { Id = 2, Title = "Физика" },
                new Course { Id = 3, Title = "Информатика" }
            );
        }
    }
}
