using MediatR;

namespace TalentFlow.Application.Users.Commands
{
    public record LoginUserCommand(string LearnerId, string Email) : IRequest<string>;
}
