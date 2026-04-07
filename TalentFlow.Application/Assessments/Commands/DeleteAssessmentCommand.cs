using MediatR;

namespace TalentFlow.Application.Assessments.Commands
{
    // Command to delete an assessment with audit info
    public record DeleteAssessmentCommand(
        Guid Id,
        string DeletedBy
    ) : IRequest<bool>;
}
