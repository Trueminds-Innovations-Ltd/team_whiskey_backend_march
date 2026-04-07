using System;
using System.Collections.Generic;
using MediatR;
using TalentFlow.Application.Lessons.DTOs;

namespace TalentFlow.Application.Lessons.Queries
{
    public record GetLessonsByCourseIdQuery(Guid CourseId)
        : IRequest<List<LessonDto>>;
}
