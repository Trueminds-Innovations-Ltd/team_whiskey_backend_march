using System;
using MediatR;

namespace TalentFlow.Application.Questions.Commands
{
    public record UpdateQuestionCommand(Guid Id, string Text, string Answer, string UpdatedBy) : IRequest<bool>;
}
