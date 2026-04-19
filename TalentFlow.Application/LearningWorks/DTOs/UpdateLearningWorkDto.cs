using MediatR;
using System;
using TalentFlow.Application.LearningWorks.DTOs;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.LearningWorks.DTOs
{
    public class UpdateLearningWorkCommand : IRequest<LearningWorkDto>
    {
        public Guid Id { get; }
        public string Title { get; }
        public string? Details { get; }
        public DateTime DueDate { get; }
        public LearningWorkState State { get; }

        public UpdateLearningWorkCommand(Guid id, string title, string? details, DateTime dueDate, LearningWorkState state)
        {
            Id = id;
            Title = title;
            Details = details;
            DueDate = dueDate;
            State = state;
        }
    }

}
