using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.DataTransferObjects.Instructor
{
    public class InstructorAddRequest
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;

        public Domain.Entities.Instructor ToInstructor()
        {
            return new Domain.Entities.Instructor(FirstName, LastName, DateOfBirth, Email, PhoneNumber, FullAddress);
        }
    }
}
