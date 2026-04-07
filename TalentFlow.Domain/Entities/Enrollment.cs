// Domain/Entities/Enrollment.cs
using System;

namespace TalentFlow.Domain.Entities
{
    public class Enrollment
    {
        public Guid Id { get; private set; }
        public Guid CourseId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime EnrolledAt { get; private set; }   // ✅ use EnrolledAt
        public string? UpdatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? DeletedBy { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public Enrollment(Guid courseId, Guid userId)
        {
            Id = Guid.NewGuid();
            CourseId = courseId;
            UserId = userId;
            EnrolledAt = DateTime.UtcNow;   // ✅ set EnrolledAt
            IsDeleted = false;
        }

        public void Update(string updatedBy)
        {
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SoftDelete(string deletedBy)
        {
            IsDeleted = true;
            DeletedBy = deletedBy;
            DeletedAt = DateTime.UtcNow;
        }
    }
}
