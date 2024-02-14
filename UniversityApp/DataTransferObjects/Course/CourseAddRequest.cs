using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.DataTransferObjects.Course
{
    public class CourseAddRequest
    {
        public string CourseName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;

        public Domain.Entities.Course ToCourse()
        {
            return new Domain.Entities.Course(CourseName, CourseCode);
        }
    }
}
