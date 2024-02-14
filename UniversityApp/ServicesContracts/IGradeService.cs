using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Grade;

namespace UniversityApp.ServicesContracts
{
    public interface IGradeService
    {
        Task<List<GradeResponse>> GetAllGrades();

        Task<GradeResponse> AddGrade(GradeAddRequest grade);

        Task<GradeResponse> UpdateGrade(GradeUpdateRequest grade);

        Task<bool> DeleteGrade(int id);
    }
}
