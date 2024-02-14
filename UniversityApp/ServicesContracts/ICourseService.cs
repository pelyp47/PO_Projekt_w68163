using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Course;

namespace UniversityApp.ServicesContracts
{
    public interface ICourseService
    {
        Task<List<CourseResponse>> GetAllCourses();

        Task<CourseResponse> AddCourse(CourseAddRequest course);

        Task<CourseResponse> UpdateCourse(CourseUpdateRequest course);

        Task<bool> DeleteCourse(int id);
    }
}
