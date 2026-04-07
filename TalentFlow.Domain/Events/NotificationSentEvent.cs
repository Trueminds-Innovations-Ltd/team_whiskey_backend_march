using TalentFlow.Domain.Common;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Domain.Events
{
    public class NotificationSentDomainEvent : DomainEvent
    {
        public Notification Notification { get; }

        public NotificationSentDomainEvent(Notification notification)
        {
            Notification = notification;
            // ❌ DO NOT set OccurredOn here
        }
    }
}