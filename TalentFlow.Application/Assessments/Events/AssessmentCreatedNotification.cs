using MediatR;
using TalentFlow.Domain.Events;

namespace TalentFlow.Application.Assessments.Events
{
    public class AssessmentCreatedNotification : INotification
    {
        public AssessmentCreatedDomainEvent DomainEvent { get; }

        public AssessmentCreatedNotification(AssessmentCreatedDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }
    }
}
