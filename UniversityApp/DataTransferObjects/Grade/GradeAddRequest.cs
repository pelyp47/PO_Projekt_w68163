using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.DataTransferObjects.Grade
{
    public class GradeAddRequest
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public double GradePoint { get; set; }

        public Domain.Entities.Grade ToGrade()
        {
            return new Domain.Entities.Grade(GradePoint, StudentId, CourseId);
        }
    }
}
