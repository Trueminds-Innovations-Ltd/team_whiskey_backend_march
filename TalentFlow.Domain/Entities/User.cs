using TalentFlow.Domain.Common;
using TalentFlow.Domain.Events;

namespace TalentFlow.Domain.Entities
{
    public class User : EntityBase
    {
        public Guid Id { get; private set; } // internal DB ID

        public string LearnerId { get; private set; } = null!; // ✅ FIX
        public string Email { get; private set; } = null!;     // ✅ FIX
        public string FullName { get; private set; } = null!;  // ✅ FIX

        private User() { } // EF Core

        public User(string learnerId, string email, string name)
        {
            // ✅ DOMAIN VALIDATION (Senior Practice)
            if (string.IsNullOrWhiteSpace(learnerId))
                throw new ArgumentException("LearnerId cannot be empty");

            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email cannot be empty");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Full name cannot be empty");

            Id = Guid.NewGuid();
            LearnerId = learnerId;
            Email = email;
            FullName = name;

            AddDomainEvent(new UserRegisteredDomainEvent(this));
        }

        public void UpdateProfile(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Full name cannot be empty");

            FullName = name;

            AddDomainEvent(new UserProfileUpdatedDomainEvent(this));
        }
    }
}