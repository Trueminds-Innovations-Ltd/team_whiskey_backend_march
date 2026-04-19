using System;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.LearningWorks.DTOs
{
    public class LearningWorkDto
    {
        public Guid Id { get; set; }
        public Guid AssignedTo { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Details { get; set; }
        public DateTime DueDate { get; set; }
        public LearningWorkState State { get; set; }
    }


}
