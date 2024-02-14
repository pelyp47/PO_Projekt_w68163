using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Domain.DataContext;
using UniversityApp.Domain.Entities;
using UniversityApp.Domain.RepositoriesContracts;

namespace UniversityApp.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly UniversityDbContext _db = new UniversityDbContext();

        public async Task<List<Grade>> GetAllGradesAsync()
        {
            return await _db.Grades.ToListAsync();
        }

        public async Task<Grade?> GetGradeAsync(int gradeId)
        {
            return await _db.Grades.FindAsync(gradeId);
        }

        public async Task<Grade> AddGradeAsync(Grade grade)
        {
            _db.Grades.Add(grade);
            await _db.SaveChangesAsync();
            return grade;
        }

        public async Task<Grade> UpdateGradeAsync(Grade grade)
        {
            var matchingGrade = await _db.Grades
                .Include(g => g.Student)
                .Include(g => g.Course)
                .FirstOrDefaultAsync(g => g.GradeId == grade.GradeId);
            if (matchingGrade == null)
            {
                throw new Exception("Grade not found");
            }

            matchingGrade.StudentId = grade.StudentId;
            matchingGrade.CourseId = grade.CourseId;
            matchingGrade.GradePoint = grade.GradePoint;

            await _db.SaveChangesAsync();

            return matchingGrade;
        }

        public async Task<bool> DeleteGradeAsync(int id)
        {
            var matchingGrade = await _db.Grades.FindAsync(id);
            if (matchingGrade == null)
            {
                throw new Exception("Grade not found");
            }

            _db.Grades.Remove(matchingGrade);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
