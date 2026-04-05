using TalentFlow.Domain.Common;
using TalentFlow.Domain.Events;

namespace TalentFlow.Domain.Entities
{
    public class Instructor : EntityBase
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Bio { get; private set; }
        public DateTime CreatedAt { get; private set; }

        private Instructor() { } // EF Core

        public Instructor(string fullName, string email, string bio)
        {
            Id = Guid.NewGuid();
            FullName = fullName;
            Email = email;
            Bio = bio;
            CreatedAt = DateTime.UtcNow;

            AddDomainEvent(new InstructorRegisteredDomainEvent(this));
        }
    }
}
