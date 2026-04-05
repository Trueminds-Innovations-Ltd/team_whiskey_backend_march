using TalentFlow.Domain.Common;
using TalentFlow.Domain.Events;

namespace TalentFlow.Domain.Entities
{
    public class User : EntityBase
    {
        public Guid Id { get; private set; } // internal DB ID, never exposed
        public string LearnerId { get; private set; } // public identifier
        public string Email { get; private set; }
        public string FullName { get; private set; }

        private User() { } // EF Core

        public User(string learnerId, string email, string name)
        {
            Id = Guid.NewGuid();
            LearnerId = learnerId;
            Email = email;
            FullName = name;

            AddDomainEvent(new UserRegisteredDomainEvent(this));
        }

        public void UpdateProfile(string name)
        {
            FullName = name;
            AddDomainEvent(new UserProfileUpdatedDomainEvent(this));
        }
    }
}
