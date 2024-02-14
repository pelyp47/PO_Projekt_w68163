using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Grade;
using UniversityApp.Domain.Entities;
using UniversityApp.Domain.RepositoriesContracts;
using UniversityApp.Repositories;
using UniversityApp.ServicesContracts;

namespace UniversityApp.Services
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository = new GradeRepository();

        public async Task<GradeResponse> AddGrade(GradeAddRequest grade)
        {
            
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade));
            }

            var newGrade = await _gradeRepository.AddGradeAsync(grade.ToGrade());
            return newGrade.ToGradeResponse();
        }

        public async Task<bool> DeleteGrade(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var grades = await _gradeRepository.GetAllGradesAsync();
            var gradeToDelete = grades.FirstOrDefault(g => g.GradeId == id);
            if (gradeToDelete == null)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await _gradeRepository.DeleteGradeAsync(id);
        }

        public async Task<List<GradeResponse>> GetAllGrades()
        {
            var grades = await _gradeRepository.GetAllGradesAsync();

            return grades.Select(g => g.ToGradeResponse()).ToList();  
        }

        public async Task<GradeResponse> UpdateGrade(GradeUpdateRequest grade)
        {
            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade));
            }

            var grades = await _gradeRepository.GetAllGradesAsync();
            var gradeToUpdate = grades.FirstOrDefault(g => g.GradeId == grade.GradeId);
            
            if (gradeToUpdate == null)
            {
                throw new ArgumentOutOfRangeException(nameof(grade.GradeId));
            }

            var updatedGrade = await _gradeRepository.UpdateGradeAsync(grade.ToGrade());
            return updatedGrade.ToGradeResponse();
        }
    }
}
