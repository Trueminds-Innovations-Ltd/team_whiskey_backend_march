// Application/Enrollments/DTOs/EnrollmentDto.cs
using System;

namespace TalentFlow.Application.Enrollments.DTOs
{
    public class EnrollmentDto
    {
        public Guid Id { get; set; }              // ✅ added
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }
        public DateTime EnrolledAt { get; set; }  // ✅ use EnrolledAt
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? DeletedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
