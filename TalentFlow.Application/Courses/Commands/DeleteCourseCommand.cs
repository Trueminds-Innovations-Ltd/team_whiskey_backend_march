using System;
using MediatR;

namespace TalentFlow.Application.Courses.Commands
{
    public record DeleteCourseCommand(Guid Id, string DeletedBy) : IRequest<bool>;
}
