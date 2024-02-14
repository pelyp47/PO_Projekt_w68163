using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.DataTransferObjects.Student
{
    public class StudentUpdateRequest
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;

        public Domain.Entities.Student ToStudent()
        {
            return new Domain.Entities.Student(StudentId, FirstName, LastName, DateOfBirth, Email, PhoneNumber, FullAddress);
        }
    }

    public static class StudentUpdateRequestExtensions
    {
        public static StudentUpdateRequest ToStudentUpdateRequest(this StudentResponse studentResponse)
        {
            return new StudentUpdateRequest
            {
                StudentId = studentResponse.StudentId,
                FirstName = studentResponse.FirstName,
                LastName = studentResponse.LastName,
                DateOfBirth = studentResponse.DateOfBirth,
                Email = studentResponse.Email,
                PhoneNumber = studentResponse.PhoneNumber,
                FullAddress = studentResponse.FullAddress
            };
        }
    }
}
