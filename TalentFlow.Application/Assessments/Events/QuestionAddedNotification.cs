using MediatR;
using TalentFlow.Domain.Events;

namespace TalentFlow.Application.Assessments.Events
{
    public class QuestionAddedNotification : INotification
    {
        public QuestionAddedDomainEvent DomainEvent { get; }

        public QuestionAddedNotification(QuestionAddedDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
