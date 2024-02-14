using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Instructor;

namespace UniversityApp.ServicesContracts
{
    public interface IInstructorService
    {
        Task<List<InstructorResponse>> GetAllInstructors();
        Task<InstructorResponse?> GetInstructorById(int id);

        Task<InstructorResponse> AddInstructor(InstructorAddRequest instructor);

        Task<InstructorResponse> UpdateInstructor(InstructorUpdateRequest instructor);

        Task<bool> DeleteInstructor(int id);
    }
}
