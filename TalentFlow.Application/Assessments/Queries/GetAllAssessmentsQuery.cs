using MediatR;
using TalentFlow.Application.Assessments.DTOs;

namespace TalentFlow.Application.Assessments.Queries
{
    public record GetAllAssessmentsQuery() : IRequest<List<AssessmentDto>>;
}
