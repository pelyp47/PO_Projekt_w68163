using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.DataTransferObjects.Instructor
{
    public class InstructorUpdateRequest
    {
        public int InstructorId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;

        public Domain.Entities.Instructor ToInstructor()
        {
            return new Domain.Entities.Instructor(InstructorId, FirstName, LastName, DateOfBirth, Email, PhoneNumber, FullAddress);
        }
    }

    public static class InstructorUpdateRequestExtensions
    {
        public static InstructorUpdateRequest ToInstructorUpdateRequest(this InstructorResponse instructorResponse)
        {
            return new InstructorUpdateRequest
            {
                InstructorId = instructorResponse.InstructorId,
                FirstName = instructorResponse.FirstName,
                LastName = instructorResponse.LastName,
                DateOfBirth = instructorResponse.DateOfBirth,
                Email = instructorResponse.Email,
                PhoneNumber = instructorResponse.PhoneNumber,
                FullAddress = instructorResponse.FullAddress
            };
        }
    }
}
