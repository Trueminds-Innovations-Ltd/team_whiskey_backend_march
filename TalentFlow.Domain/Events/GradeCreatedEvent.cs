using TalentFlow.Domain.Common;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Domain.Events
{
    public class GradeCreatedEvent : DomainEvent
    {
        public Grade Grade { get; }

        public GradeCreatedEvent(Grade grade)
        {
            Grade = grade;
        }
    }

    public class GradeUpdatedEvent : DomainEvent
    {
        public Grade Grade { get; }

        public GradeUpdatedEvent(Grade grade)
        {
            Grade = grade;
        }
    }
}
