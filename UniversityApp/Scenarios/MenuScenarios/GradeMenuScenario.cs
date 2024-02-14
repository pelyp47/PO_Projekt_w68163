using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Grade;
using UniversityApp.ServicesContracts;

namespace UniversityApp.Scenarios.MenuScenarios
{
    public class GradeMenuScenario : IMenuScenario
    {
        private readonly IGradeService _gradeService;

        public GradeMenuScenario(IGradeService gradeService)
        {
            _gradeService = gradeService;
        }

        public async Task Execute()
        {
            while (true)
            {
                Console.WriteLine("1. Add Grade");
                Console.WriteLine("2. List Grades");
                Console.WriteLine("3. Delete Grade");
                Console.WriteLine("4. Update Grade");
                Console.WriteLine("5. Exit");

                var option = Console.ReadLine();

                if (option == null)
                {
                    throw new ArgumentNullException(nameof(option));
                }

                switch (option)
                {
                    case "1":
                        await AddGrade();
                        break;
                    case "2":
                        await ListGrades();
                        break;
                    case "3":
                        await DeleteGrade();
                        break;
                    case "4":
                        await UpdateGrade();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }   
        }

        private async Task AddGrade()
        {
            Console.WriteLine("Student Id");
            var studentId = Console.ReadLine();

            Console.WriteLine("Course Id");
            var courseId = Console.ReadLine();

            Console.WriteLine("Grade");
            var grade = Console.ReadLine();

            if (studentId == null)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            if (courseId == null)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade));
            }

            var gradeAddRequest = new GradeAddRequest
            {
                StudentId = int.Parse(studentId),
                CourseId = int.Parse(courseId),
                GradePoint = double.Parse(grade)
            };

            await _gradeService.AddGrade(gradeAddRequest);
            Console.WriteLine("Grade added successfully");
        }

        private async Task ListGrades()
        {
            var grades = await _gradeService.GetAllGrades();
            foreach (var grade in grades)
            {
                Console.WriteLine($"Grade Id: {grade.GradeId}, Student Id: {grade.Student.StudentId}, Course Id: {grade.Course.CourseId}, Grade: {grade.GradePoint}");
            }
        }

        private async Task DeleteGrade()
        {
            Console.WriteLine("Enter the id of the grade to delete");
            var id = Console.ReadLine();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var gradeId = int.Parse(id);
            await _gradeService.DeleteGrade(gradeId);
            Console.WriteLine("Grade deleted successfully");
        }

        private async Task UpdateGrade()
        {
            Console.WriteLine("Enter the id of the grade to update");
            var id = Console.ReadLine();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var gradeId = int.Parse(id);

            Console.WriteLine("Student Id");
            var studentId = Console.ReadLine();

            Console.WriteLine("Course Id");
            var courseId = Console.ReadLine();

            Console.WriteLine("Grade");
            var grade = Console.ReadLine();

            if (studentId == null)
            {
                throw new ArgumentNullException(nameof(studentId));
            }

            if (courseId == null)
            {
                throw new ArgumentNullException(nameof(courseId));
            }

            if (grade == null)
            {
                throw new ArgumentNullException(nameof(grade));
            }

            var gradeUpdateRequest = new GradeUpdateRequest
            {
                GradeId = gradeId,
                StudentId = int.Parse(studentId),
                CourseId = int.Parse(courseId),
                GradePoint = double.Parse(grade)
            };

            await _gradeService.UpdateGrade(gradeUpdateRequest);
            Console.WriteLine("Grade updated successfully");
        }
    }
}
