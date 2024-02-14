using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Course;
using UniversityApp.Domain.RepositoriesContracts;
using UniversityApp.Repositories;
using UniversityApp.ServicesContracts;

namespace UniversityApp.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository = new CourseRepository();

        public async Task<CourseResponse> AddCourse(CourseAddRequest course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            var newCourse = await _courseRepository.AddCourseAsync(course.ToCourse());
            return newCourse.ToCourseResponse();
        }

        public async Task<bool> DeleteCourse(int id)
        {     
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var courses = await _courseRepository.GetAllCoursesAsync();
            var courseToDelete = courses.FirstOrDefault(c => c.CourseId == id);
            if (courseToDelete == null)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await _courseRepository.DeleteCourseAsync(id);
        }

        public async Task<List<CourseResponse>> GetAllCourses()
        {
            var courses = await _courseRepository.GetAllCoursesAsync();

            return courses.Select(c => c.ToCourseResponse()).ToList();
        }

        public async Task<CourseResponse> UpdateCourse(CourseUpdateRequest course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            var courses = await _courseRepository.GetAllCoursesAsync();
            var courseToUpdate = courses.FirstOrDefault(c => c.CourseId == course.CourseId);

            if (courseToUpdate == null)
            {
                throw new ArgumentOutOfRangeException(nameof(course.CourseId));
            }

            var updatedCourse = await _courseRepository.UpdateCourseAsync(course.ToCourse());
            return updatedCourse.ToCourseResponse();
        }
    }
}
