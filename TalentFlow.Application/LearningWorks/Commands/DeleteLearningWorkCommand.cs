using System;
using MediatR;

namespace TalentFlow.Application.LearningWorks.Commands
{
    public class DeleteLearningWorkCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteLearningWorkCommand(Guid id)
        {
            Id = id;
        }
    }
}
