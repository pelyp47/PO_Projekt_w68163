using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Domain.Entities;

namespace UniversityApp.Domain.RepositoriesContracts
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCoursesAsync();

        Task<Course> AddCourseAsync(Course course);

        Task<Course> UpdateCourseAsync(Course course);

        Task<bool> DeleteCourseAsync(int id);
    }
}
