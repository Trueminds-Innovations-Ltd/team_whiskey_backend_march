using TalentFlow.Domain.Common;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Domain.Events
{
    /// <summary>
    /// Domain event raised when a notification is sent.
    /// </summary>
    public class NotificationSentDomainEvent : DomainEvent
    {
        public Notification Notification { get; }
        public DateTime OccurredOn { get; }

        public NotificationSentDomainEvent(Notification notification)
        {
            Notification = notification;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
