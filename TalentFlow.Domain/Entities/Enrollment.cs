using TalentFlow.Domain.Common;

namespace TalentFlow.Domain.Entities
{
    public class Enrollment : EntityBase
    {
        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid CourseId { get; private set; }
        public DateTime EnrolledAt { get; private set; }

        private Enrollment() { } // EF Core

        public Enrollment(Guid userId, Guid courseId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
            CourseId = courseId;
            EnrolledAt = DateTime.UtcNow;
        }
    }
}
