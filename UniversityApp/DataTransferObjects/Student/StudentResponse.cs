using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Grade;

namespace UniversityApp.DataTransferObjects.Student
{
    public class StudentResponse
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
        public List<GradeResponse> Grades { get; set; } = new List<GradeResponse>();
    }

    public static class StudentExtensions
    {
        public static StudentResponse ToStudentResponse(this Domain.Entities.Student student)
        {
            return new StudentResponse
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                FullAddress = student.FullAddress,
                Grades = student.Grades.Select(g => g.ToGradeResponse()).ToList()
            };
        }
    }
}
