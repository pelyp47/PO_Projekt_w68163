using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityApp.DataTransferObjects.Grade;

namespace UniversityApp.DataTransferObjects.Course
{
    public class CourseResponse
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;

        public List<GradeResponse>? Grades { get; set; } = new List<GradeResponse>();
    }

    public static class CourseExtensions
    {
        public static CourseResponse ToCourseResponse(this Domain.Entities.Course course)
        {
            return new CourseResponse
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CourseCode = course.CourseCode,
                Grades = course.Grades?.Select(g => g.ToGradeResponse()).ToList()
            };
        }
    }
}
