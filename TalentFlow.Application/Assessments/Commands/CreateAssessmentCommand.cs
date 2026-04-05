using MediatR;
using TalentFlow.Application.Assessments.DTOs;

namespace TalentFlow.Application.Assessments.Commands
{
    public record CreateAssessmentCommand(string Title, string Instructions)
        : IRequest<AssessmentDto>;
}
