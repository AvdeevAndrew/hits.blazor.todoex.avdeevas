using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AcademicJournal.Models;

namespace AcademicJournal.Data
{
    public class JournalService
    {
        private readonly JournalDbContext _context;

        public JournalService(JournalDbContext context)
        {
            _context = context;
        }

        public List<Student> GetStudents()
        {
            return _context.Students.ToList();
        }

        public List<Course> GetCourses()
        {
            return _context.Courses.ToList();
        }

        public List<Grade> GetAllGrades()
        {
            // Include подгружает связанные данные (аналог SQL JOIN)
            return _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .OrderByDescending(g => g.Date)
                .ToList();
        }

        public void AddGrade(Grade grade)
        {
            grade.Date = DateTime.Now;

            // EF Core сам поймет, что нужно сделать INSERT
            _context.Grades.Add(grade);

            // Сохраняем изменения в БД (commit)
            _context.SaveChanges();
        }
    }
}
