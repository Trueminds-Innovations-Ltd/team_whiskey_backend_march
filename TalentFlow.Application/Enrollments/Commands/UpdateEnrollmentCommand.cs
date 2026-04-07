using MediatR;

namespace TalentFlow.Application.Enrollments.Commands
{
    // Command to update an enrollment with audit info
    public record UpdateEnrollmentCommand(
        Guid Id,
        string Status,
        string UpdatedBy
    ) : IRequest<bool>;
}
