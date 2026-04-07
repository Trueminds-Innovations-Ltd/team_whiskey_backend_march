using System;
using MediatR;

namespace TalentFlow.Application.Courses.Commands
{
    public record UpdateCourseCommand(Guid Id, string Title, string Description, string UpdatedBy) : IRequest<bool>;
}
