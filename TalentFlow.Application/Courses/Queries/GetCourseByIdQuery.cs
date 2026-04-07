using System;
using MediatR;
using TalentFlow.Application.Courses.DTOs;

namespace TalentFlow.Application.Courses.Queries
{
    public record GetCourseByIdQuery(Guid Id) : IRequest<CourseDto>;
}
