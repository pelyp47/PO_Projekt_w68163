using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Instructor;
using UniversityApp.Domain.RepositoriesContracts;
using UniversityApp.Repositories;
using UniversityApp.ServicesContracts;

namespace UniversityApp.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository = new InstructorRepository();

        public async Task<InstructorResponse> AddInstructor(InstructorAddRequest instructor)
        {
            if (instructor == null)
            {
                throw new ArgumentNullException(nameof(instructor));
            }

            var newInstructor = await _instructorRepository.AddInstructorAsync(instructor.ToInstructor());
            return newInstructor.ToInstructorResponse();
        }

        public async Task<bool> DeleteInstructor(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            var instructor = await _instructorRepository.GetInstructorByIdAsync(id);
            if (instructor == null)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }

            return await _instructorRepository.DeleteInstructorAsync(id);
        }

        public async Task<List<InstructorResponse>> GetAllInstructors()
        {
            var instructors = await _instructorRepository.GetAllInstructorsAsync();

            return instructors.Select(i => i.ToInstructorResponse()).ToList();
        }

        public async Task<InstructorResponse?> GetInstructorById(int id)
        {
            var instructor = await _instructorRepository.GetInstructorByIdAsync(id);
            return instructor?.ToInstructorResponse();
        }

        public async Task<InstructorResponse> UpdateInstructor(InstructorUpdateRequest instructor)
        {
            if (instructor == null)
            {
                throw new ArgumentNullException(nameof(instructor));
            }

            var instructorToUpdate = await _instructorRepository.GetInstructorByIdAsync(instructor.InstructorId);
            if (instructorToUpdate == null)
            {
                throw new ArgumentOutOfRangeException(nameof(instructor.InstructorId));
            }

            var updatedInstructor = await _instructorRepository.UpdateInstructorAsync(instructor.ToInstructor());
            return updatedInstructor.ToInstructorResponse();
        }
    }
}
