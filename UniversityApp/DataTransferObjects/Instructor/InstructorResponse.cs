using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.DataTransferObjects.Instructor
{
    public class InstructorResponse
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public DateTime HireDate { get; set; } = DateTime.MinValue;
    }

    public static class InstructorExtensions
    {
        public static InstructorResponse ToInstructorResponse(this Domain.Entities.Instructor instructor)
        {
            return new InstructorResponse
            {
                InstructorId = instructor.InstructorId,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                DateOfBirth = instructor.DateOfBirth,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                FullAddress = instructor.FullAddress,
                HireDate = instructor.HireDate
            };
        }
    }
}
