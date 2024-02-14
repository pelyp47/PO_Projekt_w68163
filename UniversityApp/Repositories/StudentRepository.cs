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
    public class StudentRepository : IStudentRepository
    {
        private readonly UniversityDbContext _db = new UniversityDbContext();

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _db.Students
                .Include(s => s.Grades)
                    .ThenInclude(g => g.Course)
                .ToListAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _db.Students
                .Include(s => s.Grades)
                    .ThenInclude(g => g.Course)
                .FirstOrDefaultAsync(s => s.StudentId == id);
        }

        public async Task<Student> AddStudentAsync(Student student)
        {
            _db.Students.Add(student);
            await _db.SaveChangesAsync();
            return student;
        }

        public async Task<Student> UpdateStudentAsync(Student student)
        {
            var matchingStudent = await _db.Students.FindAsync(student.StudentId);
            if (matchingStudent == null)
            {
                throw new Exception("Student not found");
            }

            matchingStudent.FirstName = student.FirstName;
            matchingStudent.LastName = student.LastName;
            matchingStudent.Email = student.Email;
            matchingStudent.PhoneNumber = student.PhoneNumber;
            matchingStudent.DateOfBirth = student.DateOfBirth;
            matchingStudent.FullAddress = student.FullAddress;

            await _db.SaveChangesAsync();

            return matchingStudent;
        } 

        public async Task<bool> DeleteStudentAsync(int id)
        {
            var matchingStudent = await _db.Students.FindAsync(id);
            if (matchingStudent == null)
            {
                throw new Exception("Student not found");
            }

            _db.Students.Remove(matchingStudent);
            await _db.SaveChangesAsync();

            return true;
        }
    }
}
