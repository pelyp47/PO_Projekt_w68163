using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Domain.Entities
{
    public class Student : UniversityMember
    {
        public int StudentId { get; set; }

        public List<Grade> Grades { get; set; } = new List<Grade>();

        public Student(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber, string fullAddress)
            : base(firstName, lastName, dateOfBirth, email, phoneNumber, fullAddress)
        {
        }

        public Student(int studentId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber, string fullAddress)
            : base(firstName, lastName, dateOfBirth, email, phoneNumber, fullAddress)
        {
            StudentId = studentId;
        }

        public override string GetDetails()
        {
            return $"{FirstName} {LastName} studying at the university, now he/she is {DateTime.Now.Year - DateOfBirth.Year} years old. Contact him/her at {Email} or {PhoneNumber}.";
        }
    }
}
