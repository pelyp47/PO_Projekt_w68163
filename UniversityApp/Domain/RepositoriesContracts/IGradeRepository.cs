using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Domain.Entities;

namespace UniversityApp.Domain.RepositoriesContracts
{
    public interface IGradeRepository
    {
        Task<List<Grade>> GetAllGradesAsync();

        Task<Grade> AddGradeAsync(Grade grade);

        Task<Grade> UpdateGradeAsync(Grade grade);

        Task<bool> DeleteGradeAsync(int id);
        Task<Grade?> GetGradeAsync(int gradeId);
    }
}
