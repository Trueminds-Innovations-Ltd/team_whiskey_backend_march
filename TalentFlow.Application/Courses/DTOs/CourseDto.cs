using System;
using System.Collections.Generic;
using TalentFlow.Application.Enrollments.DTOs;

namespace TalentFlow.Application.Courses.DTOs
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }

        // Audit fields
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }

        // Optional: include enrollments if you want them in the response
        public List<EnrollmentDto> Enrollments { get; set; } = new();
    }
}
