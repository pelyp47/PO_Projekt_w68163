using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Student;

namespace UniversityApp.ServicesContracts
{
    public interface IStudentService
    {
        Task<List<StudentResponse>> GetAllStudents();
        Task<StudentResponse?> GetStudentById(int id);

        Task<StudentResponse> AddStudent(StudentAddRequest student);

        Task<StudentResponse> UpdateStudent(StudentUpdateRequest student);

        Task<bool> DeleteStudent(int id);
    }
}
