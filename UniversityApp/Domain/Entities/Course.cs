using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Domain.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;

        public virtual List<Grade> Grades { get; set; } = null!;

        public Course(string courseName, string courseCode)
        {
            CourseName = courseName;
            CourseCode = courseCode;
        }

        public Course(int courseId, string courseName, string courseCode)
        {
            CourseId = courseId;
            CourseName = courseName;
            CourseCode = courseCode;
        }
    }
}
