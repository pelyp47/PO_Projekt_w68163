using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Domain.Entities
{
    public class Instructor : UniversityMember
    {
        public int InstructorId { get; set; }
        public DateTime HireDate { get; set; } = DateTime.Now;

        public Instructor(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber, string fullAddress)
            : base(firstName, lastName, dateOfBirth, email, phoneNumber, fullAddress)
        { }

        public Instructor(int instructorId, string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber, string fullAddress)
            : base(firstName, lastName, dateOfBirth, email, phoneNumber, fullAddress)
        {
            InstructorId = instructorId;
        }

        public override string GetDetails()
        {
            return $"{FirstName} {LastName} working for the university almost {DateTime.Now.Year - HireDate.Year} years. Contact him/her at {Email} or {PhoneNumber}.";
        }
    }
}
