using TalentFlow.Domain.Common;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Domain.Events
{
    public class UserRegisteredDomainEvent : IDomainEvent
    {
        public User User { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public UserRegisteredDomainEvent(User user)
        {
            User = user;
        }
    }
}
