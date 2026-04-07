using System;
using MediatR;

namespace TalentFlow.Application.Enrollments.Commands
{
    public record UnenrollLearnerCommand(Guid CourseId, Guid UserId, string DeletedBy) : IRequest<bool>;
}
