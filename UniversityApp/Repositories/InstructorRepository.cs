using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.Domain.DataContext;
using UniversityApp.Domain.Entities;
using UniversityApp.Domain.RepositoriesContracts;

namespace UniversityApp.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly UniversityDbContext _db = new UniversityDbContext();

        public async Task<List<Instructor>> GetAllInstructorsAsync()
        {
            return await _db.Instructors.ToListAsync();
        }

        public async Task<Instructor?> GetInstructorByIdAsync(int id)
        {
            return await _db.Instructors.FindAsync(id);
        }

        public async Task<Instructor> AddInstructorAsync(Instructor instructor)
        {
            _db.Instructors.Add(instructor);
            await _db.SaveChangesAsync();
            return instructor;
        }

        public async Task<Instructor> UpdateInstructorAsync(Instructor instructor)
        {
            var matchingInstructor = await _db.Instructors.FindAsync(instructor.InstructorId);
            if (matchingInstructor == null)
            {
                throw new Exception("Instructor not found");
            }
            
            matchingInstructor.FirstName = instructor.FirstName;
            matchingInstructor.LastName = instructor.LastName;
            matchingInstructor.Email = instructor.Email;
            matchingInstructor.PhoneNumber = instructor.PhoneNumber;
            matchingInstructor.DateOfBirth = instructor.DateOfBirth;
            matchingInstructor.FullAddress = instructor.FullAddress;

            await _db.SaveChangesAsync();

            return matchingInstructor;
        }

        public async Task<bool> DeleteInstructorAsync(int id)
        {
            var matchingInstructor = await _db.Instructors.FindAsync(id);
            if (matchingInstructor == null)
            {
                throw new Exception("Instructor not found");
            }

            _db.Instructors.Remove(matchingInstructor);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
