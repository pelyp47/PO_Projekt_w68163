using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Domain.Entities
{
    public abstract class UniversityMember
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } = DateTime.MinValue;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;

        public UniversityMember(string firstName, string lastName, DateTime dateOfBirth, string email, string phoneNumber, string fullAddress)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Email = email;
            PhoneNumber = phoneNumber;
            FullAddress = fullAddress;
        }

        public abstract string GetDetails();

        public override string ToString()
        {
            return $"{FirstName} {LastName} - {DateOfBirth} - {Email}, {PhoneNumber}";
        }
    }
}
