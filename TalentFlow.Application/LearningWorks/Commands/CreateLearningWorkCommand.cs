using System;
using MediatR;
using TalentFlow.Application.LearningWorks.DTOs;

namespace TalentFlow.Application.LearningWorks.Commands
{
    public class CreateLearningWorkCommand : IRequest<LearningWorkDto>
    {
        public Guid AssignedTo { get; }
        public string Title { get; }
        public string? Details { get; }
        public DateTime DueDate { get; }

        public CreateLearningWorkCommand(Guid assignedTo, string title, string? details, DateTime dueDate)
        {
            AssignedTo = assignedTo;
            Title = title;
            Details = details;
            DueDate = dueDate;
        }
    }
}
