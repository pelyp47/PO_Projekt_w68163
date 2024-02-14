using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityApp.DataTransferObjects.Course
{
    public class CourseUpdateRequest
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public string CourseCode { get; set; } = string.Empty;

        public Domain.Entities.Course ToCourse()
        {
            return new Domain.Entities.Course(CourseId, CourseName, CourseCode);
        }
    }

    public static class CourseUpdateRequestExtensions
    {
        public static CourseUpdateRequest ToCourseUpdateRequest(this CourseResponse courseResponse)
        {
            return new CourseUpdateRequest
            {
                CourseId = courseResponse.CourseId,
                CourseName = courseResponse.CourseName,
                CourseCode = courseResponse.CourseCode
            };
        }
    }
}
