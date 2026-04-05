using MediatR;

namespace TalentFlow.Application.Assessments.Commands
{
    /// <summary>
    /// Command to add a new question to an assessment.
    /// Returns true if successful, false otherwise.
    /// </summary>
    public record AddQuestionCommand(
        Guid AssessmentId,
        string Text,
        string Answer
    ) : IRequest<bool>;
}
