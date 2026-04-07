using System;
using MediatR;

namespace TalentFlow.Application.Enrollments.Commands
{
    public record EnrollLearnerCommand(Guid CourseId, Guid UserId, string EnrolledBy) : IRequest<bool>;
}
