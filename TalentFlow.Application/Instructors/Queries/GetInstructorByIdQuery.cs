using MediatR;
using TalentFlow.Application.Instructors.DTOs;

namespace TalentFlow.Application.Instructors.Queries
{
    public record GetInstructorByIdQuery(Guid Id) : IRequest<InstructorDto?>;
}
