using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Domain.DataContext;
using UniversityApp.Domain.Entities;
using UniversityApp.Domain.RepositoriesContracts;

namespace UniversityApp.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly UniversityDbContext _db = new UniversityDbContext();

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            return await _db.Courses.ToListAsync();
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return course;
        }

        public async Task<Course> UpdateCourseAsync(Course course)
        {
            var matchingCourse = await _db.Courses.FindAsync(course.CourseId);
            if (matchingCourse == null)
            {
                throw new Exception("Course not found");
            }
            
            matchingCourse.CourseName = course.CourseName;
            matchingCourse.CourseCode = course.CourseCode;

            await _db.SaveChangesAsync();

            return matchingCourse;
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            var matchingCourse = await _db.Courses.FindAsync(id);
            if (matchingCourse == null)
            {
                throw new Exception("Course not found");
            }

            _db.Courses.Remove(matchingCourse);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
