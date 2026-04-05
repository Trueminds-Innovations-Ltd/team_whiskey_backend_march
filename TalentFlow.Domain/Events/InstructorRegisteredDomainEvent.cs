using TalentFlow.Domain.Common;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Domain.Events
{
    public class InstructorRegisteredDomainEvent : IDomainEvent
    {
        public Instructor Instructor { get; }
        public DateTime OccurredOn { get; } = DateTime.UtcNow;

        public InstructorRegisteredDomainEvent(Instructor instructor)
        {
            Instructor = instructor;
        }
    }
}
