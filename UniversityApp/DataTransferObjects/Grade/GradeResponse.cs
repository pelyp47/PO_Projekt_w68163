using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Course;
using UniversityApp.DataTransferObjects.Student;

namespace UniversityApp.DataTransferObjects.Grade
{
    public class GradeResponse
    {
        public int GradeId { get; set; }
        public double GradePoint { get; set; }
        public DateTime DateGraded { get; set; }

        public StudentResponse Student { get; set; } = null!;

        public CourseResponse Course { get; set; } = null!;
    }

    public static class GradeResponseExtensions
    {
        public static GradeResponse ToGradeResponse(this Domain.Entities.Grade grade)
        {
            return new GradeResponse
            {
                GradeId = grade.GradeId,
                GradePoint = grade.GradePoint,
                DateGraded = grade.DateGraded,
                Student = grade.Student.ToStudentResponse(),
                Course = grade.Course.ToCourseResponse()
            };
        }
    }
}
