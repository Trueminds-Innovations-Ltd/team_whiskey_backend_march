using System;
using System.Collections.Generic;
using TalentFlow.Application.Enrollments.DTOs;

namespace TalentFlow.Application.Courses.DTOs
{
    public class CourseEnrollmentDto
    {
        public Guid CourseId { get; set; }
        public string CourseTitle { get; set; } = string.Empty;

        // List of learners enrolled in the course
        public List<EnrollmentDto> Enrollments { get; set; } = new();
    }
}
