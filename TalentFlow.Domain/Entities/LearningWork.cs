using System;

namespace TalentFlow.Domain.Entities
{
    public class LearningWork
    {
        public Guid Id { get; set; }
        public Guid AssignedTo { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Details { get; set; }
        public DateTime DueDate { get; set; }
        public LearningWorkState State { get; set; } = LearningWorkState.Pending;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
    }


    public enum LearningWorkState
    {
        Pending,
        InProgress,
        Completed
    }
}
