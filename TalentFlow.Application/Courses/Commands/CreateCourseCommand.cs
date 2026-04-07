// Application/Courses/Commands/CreateCourseCommand.cs
using System;
using MediatR;

namespace TalentFlow.Application.Courses.Commands
{
    public record CreateCourseCommand(string Title, string Description, string Slug) : IRequest<Guid>;
}
