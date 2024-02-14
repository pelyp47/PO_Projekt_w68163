using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Student;
using UniversityApp.Domain.RepositoriesContracts;
using UniversityApp.Repositories;
using UniversityApp.ServicesContracts;

namespace UniversityApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository = new StudentRepository();

        public async Task<StudentResponse> AddStudent(StudentAddRequest student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var newStudent = student.ToStudent();
            return newStudent.ToStudentResponse();
        }

        public async Task<bool> DeleteStudent(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var student = await _studentRepository.GetStudentByIdAsync(id);
            if (student == null)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await _studentRepository.DeleteStudentAsync(id);
        }

        public async Task<List<StudentResponse>> GetAllStudents()
        {
            var students = await _studentRepository.GetAllStudentsAsync();

            return students.Select(s => s.ToStudentResponse()).ToList();
        }

        public async Task<StudentResponse?> GetStudentById(int id)
        {
            var student = await _studentRepository.GetStudentByIdAsync(id);

            return student?.ToStudentResponse();
        }

        public async Task<StudentResponse> UpdateStudent(StudentUpdateRequest student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            var studentToUpdate = await _studentRepository.GetStudentByIdAsync(student.StudentId);
            if (studentToUpdate == null)
            {
                throw new ArgumentOutOfRangeException(nameof(student.StudentId));
            }

            var updatedStudent = await _studentRepository.UpdateStudentAsync(student.ToStudent());
            return updatedStudent.ToStudentResponse();
        }
    }
}
