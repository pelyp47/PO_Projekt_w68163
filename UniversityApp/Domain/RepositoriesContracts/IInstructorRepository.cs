using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Domain.Entities;

namespace UniversityApp.Domain.RepositoriesContracts
{
    public interface IInstructorRepository
    {
        Task<List<Instructor>> GetAllInstructorsAsync();
        Task<Instructor?> GetInstructorByIdAsync(int id);

        Task<Instructor> AddInstructorAsync(Instructor instructor);

        Task<Instructor> UpdateInstructorAsync(Instructor instructor);

        Task<bool> DeleteInstructorAsync(int id);
    }
}
