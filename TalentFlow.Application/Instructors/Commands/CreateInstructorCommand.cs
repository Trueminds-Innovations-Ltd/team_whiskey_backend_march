using MediatR;
using TalentFlow.Application.Instructors.DTOs;

namespace TalentFlow.Application.Instructors.Commands
{
    public record CreateInstructorCommand(string FullName, string Email, string Bio)
        : IRequest<InstructorDto>;
}
