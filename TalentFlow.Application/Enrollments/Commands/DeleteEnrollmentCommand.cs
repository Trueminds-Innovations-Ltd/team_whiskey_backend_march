using MediatR;

namespace TalentFlow.Application.Enrollments.Commands
{
    // Command to delete an enrollment with audit info
    public record DeleteEnrollmentCommand(
        Guid Id,
        string DeletedBy
    ) : IRequest<bool>;
}
