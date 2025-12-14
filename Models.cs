using System;
using System.ComponentModel.DataAnnotations;

namespace AcademicJournal.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }

    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
    }

    public class Grade
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Выберите студента")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Выберите курс")]
        public int CourseId { get; set; }

        [Range(1, 5, ErrorMessage = "Оценка должна быть от 1 до 5")]
        public int Score { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        // Навигационные свойства для удобства отображения (опционально, но полезно)
        public Student? Student { get; set; }
        public Course? Course { get; set; }
    }
}
