using MediatR;

namespace TalentFlow.Application.Assessments.Commands
{
    // Command to update an assessment with audit info
    public record UpdateAssessmentCommand(
        Guid Id,
        string Title,
        string Description,
        string UpdatedBy
    ) : IRequest<bool>;
}
