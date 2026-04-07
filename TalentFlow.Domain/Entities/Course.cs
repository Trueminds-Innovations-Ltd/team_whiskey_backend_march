using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    public class Course : EntityBase
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Slug { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;

        // Audit fields
        public string? UpdatedBy { get; private set; }
        public DateTime? UpdatedAt { get; private set; }
        public string? DeletedBy { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        // Enrollments collection
        private readonly List<Enrollment> _enrollments = new();
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments.AsReadOnly();

        private Course() { } // EF Core

        public Course(string title, string description, string slug)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Slug = slug;
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        public void UpdateDetails(string title, string description, string updatedBy)
        {
            Title = title;
            Description = description;
            UpdatedBy = updatedBy;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SoftDelete(string deletedBy)
        {
            IsDeleted = true;
            DeletedBy = deletedBy;
            DeletedAt = DateTime.UtcNow;
        }

        // Domain/Entities/Course.cs
        public void Enroll(User learner)
        {
            var enrollment = new Enrollment(Id, learner.Id); // ✅ use learner.Id
            _enrollments.Add(enrollment);
        }

    }
}
