using System;

namespace TalentFlow.Application.LearningWorks.DTOs
{
    public class CreateLearningWorkDto
    {
        public Guid AssignedTo { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Details { get; set; }
        public DateTime DueDate { get; set; }
    }
}
