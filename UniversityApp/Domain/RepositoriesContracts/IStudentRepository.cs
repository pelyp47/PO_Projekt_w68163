using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Domain.Entities;

namespace UniversityApp.Domain.RepositoriesContracts
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int id);

        Task<Student> AddStudentAsync(Student student);

        Task<Student> UpdateStudentAsync(Student student);

        Task<bool> DeleteStudentAsync(int id);
    }
}
