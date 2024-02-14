using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.DataTransferObjects.Grade
{
    public class GradeUpdateRequest
    {
        public int GradeId { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double GradePoint { get; set; }

        public Domain.Entities.Grade ToGrade()
        {
            return new Domain.Entities.Grade(GradeId, GradePoint, StudentId, CourseId);
        }
    }

    public static class GradeUpdateRequestExtensions
    {
        public static GradeUpdateRequest ToGradeUpdateRequest(this GradeResponse gradeResponse)
        {
            return new GradeUpdateRequest
            {
                GradeId = gradeResponse.GradeId,
                StudentId = gradeResponse.Student.StudentId,
                CourseId = gradeResponse.Course.CourseId,
                GradePoint = gradeResponse.GradePoint
            };
        }
    }
}
