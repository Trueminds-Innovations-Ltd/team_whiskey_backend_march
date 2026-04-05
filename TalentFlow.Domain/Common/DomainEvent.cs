namespace TalentFlow.Domain.Common
{
    /// <summary>
    /// Marker interface for domain events.
    /// </summary>
   

    /// <summary>
    /// Base class for all domain events.
    /// Provides OccurredOn timestamp.
    /// </summary>
    public abstract class DomainEvent : IDomainEvent
    {
        public DateTime OccurredOn { get; }

        protected DomainEvent()
        {
            OccurredOn = DateTime.UtcNow;
        }
    }
}
