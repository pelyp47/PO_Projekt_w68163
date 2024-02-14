using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Instructor;
using UniversityApp.ServicesContracts;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UniversityApp.Scenarios.MenuScenarios
{
    public class InstructorMenuScenario : IMenuScenario
    {
        private readonly IInstructorService _instructorService;

        public InstructorMenuScenario(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        public async Task Execute()
        {
            while (true)
            {
                Console.WriteLine("1. Add Instructor");
                Console.WriteLine("2. List Instructors");
                Console.WriteLine("3. Find Instructor");
                Console.WriteLine("4. Delete Instructor");
                Console.WriteLine("5. Update Instructor");
                Console.WriteLine("6. Exit");     

                var option = Console.ReadLine();

                if (option == null)
                {
                    throw new ArgumentNullException(nameof(option));
                }

                switch (option)
                {
                    case "1":
                        await AddInstructor();
                        break;
                    case "2":
                        await ListInstructors();
                        break;
                    case "3":
                        await FindInstructor();
                        break;
                    case "4":
                        await DeleteInstructor();
                        break;
                    case "5":
                        await UpdateInstructor();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }

        private async Task AddInstructor()
        {
            Console.WriteLine("Enter the first name of the instructor");
            var firstName = Console.ReadLine();

            Console.WriteLine("Enter the last name of the instructor");
            var lastName = Console.ReadLine();

            Console.WriteLine("Enter the date of birth of the instructor");
            var dateOfBirth = Console.ReadLine();

            Console.WriteLine("Enter the email of the instructor");
            var email = Console.ReadLine();

            Console.WriteLine("Enter the phone number of the instructor");
            var phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter the address of the instructor");
            var address = Console.ReadLine();

            if (firstName == null)
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (lastName == null)
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            if (dateOfBirth == null)
            {
                throw new ArgumentNullException(nameof(dateOfBirth));
            }

            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (phoneNumber == null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            var instructorAddRequest = new InstructorAddRequest
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = DateTime.Parse(dateOfBirth),
                Email = email,
                PhoneNumber = phoneNumber,
                FullAddress = address
            };

            await _instructorService.AddInstructor(instructorAddRequest);
            Console.WriteLine("Instructor added successfully");
        }

        private async Task ListInstructors()
        {
            var instructors = await _instructorService.GetAllInstructors();

            foreach (var instructor in instructors)
            {
                Console.WriteLine($"Instructor Id: {instructor.InstructorId}, First Name: {instructor.FirstName}, Last Name: {instructor.LastName}, Date of Birth: {instructor.DateOfBirth}, Email: {instructor.Email}, Phone Number: {instructor.PhoneNumber}, Full Address: {instructor.FullAddress}");
            }
        }

        private async Task FindInstructor()
        {
            Console.WriteLine("Enter the id of the instructor to find");
            var id = Console.ReadLine();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var instructorId = int.Parse(id);
            var instructor = await _instructorService.GetInstructorById(instructorId);

            if (instructor == null)
            {
                Console.WriteLine("Instructor not found");
                return;
            }

            Console.WriteLine($"Instructor Id: {instructor.InstructorId}, First Name: {instructor.FirstName}, Last Name: {instructor.LastName}, Date of Birth: {instructor.DateOfBirth}, Email: {instructor.Email}, Phone Number: {instructor.PhoneNumber}, Full Address: {instructor.FullAddress}");
        }

        private async Task DeleteInstructor()
        {
            Console.WriteLine("Enter the id of the instructor to delete");
            var id = Console.ReadLine();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var instructorId = int.Parse(id);
            await _instructorService.DeleteInstructor(instructorId);
            Console.WriteLine("Instructor deleted successfully");
        }

        private async Task UpdateInstructor()
        {
            Console.WriteLine("Enter the id of the instructor to update");
            var id = Console.ReadLine();

            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            var instructorId = int.Parse(id);

            Console.WriteLine("First Name");
            var firstName = Console.ReadLine();

            Console.WriteLine("Last Name");
            var lastName = Console.ReadLine();

            Console.WriteLine("Date of Birth");
            var dateOfBirth = Console.ReadLine();

            Console.WriteLine("Email");
            var email = Console.ReadLine();

            Console.WriteLine("Phone Number");
            var phoneNumber = Console.ReadLine();

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

            if (dateOfBirth == null)
            {
                throw new ArgumentNullException(nameof(dateOfBirth));
            }

            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (phoneNumber == null)
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }

            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            var instructorUpdateRequest = new InstructorUpdateRequest
            {
                InstructorId = instructorId,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = DateTime.Parse(dateOfBirth),
                Email = email,
                PhoneNumber = phoneNumber,
                FullAddress = address
            };

            await _instructorService.UpdateInstructor(instructorUpdateRequest);
            Console.WriteLine("Instructor updated successfully");
        }
    }
}
