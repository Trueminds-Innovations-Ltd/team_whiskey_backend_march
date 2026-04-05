using MediatR;
using TalentFlow.Application.Instructors.DTOs;

namespace TalentFlow.Application.Instructors.Queries
{
    public record GetAllInstructorsQuery() : IRequest<List<InstructorDto>>;
}
