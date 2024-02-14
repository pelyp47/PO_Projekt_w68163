using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Student;
using UniversityApp.ServicesContracts;

namespace UniversityApp.Scenarios.MenuScenarios
{
    public class StudentMenuScenario : IMenuScenario
    {
        private readonly IStudentService _studentService;

        public StudentMenuScenario(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public async Task Execute()
        {
            while (true)
            {
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. List Students");
                Console.WriteLine("3. Find Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Update Student");
                Console.WriteLine("6. Exit");
               

                var option = Console.ReadLine();

                if (option == null)
                {
                    throw new ArgumentNullException(nameof(option));
                }

                switch (option)
                {
                    case "1":
                        await AddStudent();
                        break;
                    case "2":
                        await ListStudents();
                        break;
                    case "3":
                        await FindStudent();
                        break;
                    case "4":
                        await DeleteStudent();
                        break;
                    case "5":
                        await UpdateStudent();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private async Task AddStudent()
        {
            Console.WriteLine("First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("Last Name");
            var lastName = Console.ReadLine();

            Console.WriteLine("Birth Date");
            var birthDate = Console.ReadLine();

            Console.WriteLine("Email");
            var email = Console.ReadLine();

            Console.WriteLine("Phone");
            var phone = Console.ReadLine();

            Console.WriteLine("Address");
            var address = Console.ReadLine();

            if (firstName == null)
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (lastName == null)
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            if (birthDate == null)
            {
                throw new ArgumentNullException(nameof(birthDate));
            }

            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (phone == null)
            {
                throw new ArgumentNullException(nameof(phone));
            }

            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            var studentAddRequest = new StudentAddRequest
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = DateTime.Parse(birthDate),
                Email = email,
                PhoneNumber = phone,
                FullAddress = address
            };

            await _studentService.AddStudent(studentAddRequest);
            Console.WriteLine("Student added successfully");
        }

        private async Task ListStudents()
        {
            var students = await _studentService.GetAllStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"Student Id: {student.StudentId}, First Name: {student.FirstName}, Last Name: {student.LastName}, Email: {student.Email}, Phone: {student.PhoneNumber}, Address: {student.FullAddress}");
            }
        }

        private async Task FindStudent()
        {
            Console.WriteLine("Enter the id of the student to find");
            var id = Console.ReadLine();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var studentId = int.Parse(id);
            var student = await _studentService.GetStudentById(studentId);

            if (student == null)
            {
                Console.WriteLine("Student not found");
                return;
            }

            Console.WriteLine($"Student Id: {student.StudentId}, First Name: {student.FirstName}, Last Name: {student.LastName}, Email: {student.Email}, Phone: {student.PhoneNumber}, Address: {student.FullAddress}");
        }

        private async Task DeleteStudent()
        {
            Console.WriteLine("Enter the id of the student to delete");
            var id = Console.ReadLine();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var studentId = int.Parse(id);
            await _studentService.DeleteStudent(studentId);
            Console.WriteLine("Student deleted successfully");
        }

        private async Task UpdateStudent()
        {
            Console.WriteLine("Enter the id of the student to update");
            var id = Console.ReadLine();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var studentId = int.Parse(id);

            Console.WriteLine("First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("Last Name");
            var lastName = Console.ReadLine();

            Console.WriteLine("Birth Date");
            var birthDate = Console.ReadLine();

            Console.WriteLine("Email");
            var email = Console.ReadLine();

            Console.WriteLine("Phone");
            var phone = Console.ReadLine();

            Console.WriteLine("Address");
            var address = Console.ReadLine();

            if (firstName == null)
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (lastName == null)
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            if (birthDate == null)
            {
                throw new ArgumentNullException(nameof(birthDate));
            }

            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (phone == null)
            {
                throw new ArgumentNullException(nameof(phone));
            }

            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            var studentUpdateRequest = new StudentUpdateRequest
            {
                StudentId = studentId,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = DateTime.Parse(birthDate),
                Email = email,
                PhoneNumber = phone,
                FullAddress = address
            };

            await _studentService.UpdateStudent(studentUpdateRequest);
            Console.WriteLine("Student updated successfully");
        }
    }
}
