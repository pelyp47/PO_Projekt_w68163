using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.Domain.Entities
{
    public class Grade
    {
        public int GradeId { get; set; }
        public double GradePoint { get; set; }
        public DateTime DateGraded { get; set; } = DateTime.Now;

        public int StudentId { get; set; }
        public virtual Student Student { get; set; } = null!;

        public int CourseId { get; set; }
        public virtual Course Course { get; set; } = null!;

        public Grade(double gradePoint, int studentId, int courseId)
        {
            GradePoint = gradePoint;
            StudentId = studentId;
            CourseId = courseId;
        }

        public Grade(int gradeId, double gradePoint, int studentId, int courseId)
        {
            GradeId = gradeId;
            GradePoint = gradePoint;
            StudentId = studentId;
            CourseId = courseId;
        }
    }
}
