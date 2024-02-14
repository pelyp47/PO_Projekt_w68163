using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Course;
using UniversityApp.ServicesContracts;

namespace UniversityApp.Scenarios.MenuScenarios
{
    public class CourseMenuScenario : IMenuScenario
    {
        private readonly ICourseService _courseService;

        public CourseMenuScenario(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task Execute()
        {
            while (true)
            {

                Console.WriteLine("1. Add Course");
                Console.WriteLine("2. List Courses");
                Console.WriteLine("3. Delete Course");
                Console.WriteLine("4. Update Course");
                Console.WriteLine("5. Exit");

                var option = Console.ReadLine();

                if (option == null)
                {
                    throw new ArgumentNullException(nameof(option));
                }

                switch (option)
                {
                    case "1":
                        await AddCourse();
                        break;
                    case "2":
                        await ListCourses();
                        break;
                    case "3":
                        await DeleteCourse();
                        break;
                    case "4":
                        await UpdateCourse();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            
        }

        private async Task AddCourse()
        {
            Console.WriteLine("Enter the name of the course");
            var name = Console.ReadLine();

            Console.WriteLine("Enter the code of the course");
            var code = Console.ReadLine();

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            var courseAddRequest = new CourseAddRequest
            {
                CourseName = name,
                CourseCode = code
            };

            await _courseService.AddCourse(courseAddRequest);
            Console.WriteLine("Course added successfully");
        }

        private async Task ListCourses()
        {
            var courses = await _courseService.GetAllCourses();

            foreach (var course in courses)
            {
                Console.WriteLine($"Course Id: {course.CourseId}, Course Name: {course.CourseName}, Course Code: {course.CourseCode}");
            }
        }

        private async Task DeleteCourse()
        {
            Console.WriteLine("Enter the id of the course to delete");
            var id = Console.ReadLine();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var courseId = int.Parse(id);
            await _courseService.DeleteCourse(courseId);
            Console.WriteLine("Course deleted successfully");
        }

        private async Task UpdateCourse()
        {
            Console.WriteLine("Enter the id of the course to update");
            var id = Console.ReadLine();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var courseId = int.Parse(id);

            Console.WriteLine("Enter the name of the course");
            var name = Console.ReadLine();

            Console.WriteLine("Enter the code of the course");
            var code = Console.ReadLine();

            if (name == null)
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (code == null)
            {
                throw new ArgumentNullException(nameof(code));
            }

            var courseUpdateRequest = new CourseUpdateRequest
            {
                CourseId = courseId,
                CourseName = name,
                CourseCode = code
            };

            await _courseService.UpdateCourse(courseUpdateRequest);
            Console.WriteLine("Course updated successfully");
        }
    }
}
