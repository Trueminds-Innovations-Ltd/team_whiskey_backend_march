using MediatR;
using TalentFlow.Application.Assessments.DTOs;

namespace TalentFlow.Application.Assessments.Queries
{
    public record GetAssessmentByIdQuery(Guid Id) : IRequest<AssessmentDto>;
}
