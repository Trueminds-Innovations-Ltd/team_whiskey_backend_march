using System;
using MediatR;

namespace TalentFlow.Application.Questions.Commands
{
    public record DeleteQuestionCommand(Guid Id) : IRequest<bool>;
}
