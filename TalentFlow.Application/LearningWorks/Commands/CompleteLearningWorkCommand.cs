using System;
using MediatR;
using TalentFlow.Application.LearningWorks.DTOs;

namespace TalentFlow.Application.LearningWorks.Commands
{
    public class CompleteLearningWorkCommand : IRequest<LearningWorkDto>
    {
        public Guid Id { get; }

        public CompleteLearningWorkCommand(Guid id)
        {
            Id = id;
        }
    }
}
