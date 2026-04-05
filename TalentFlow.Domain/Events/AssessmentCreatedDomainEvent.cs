using TalentFlow.Domain.Common;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Domain.Events
{
    /// <summary>
    /// Domain event raised when a new assessment is created.
    /// </summary>
    public class AssessmentCreatedDomainEvent : DomainEvent
    {
        public Assessment Assessment { get; }

        public AssessmentCreatedDomainEvent(Assessment assessment)
            : base()
        {
            Assessment = assessment;
        }
    }
}
