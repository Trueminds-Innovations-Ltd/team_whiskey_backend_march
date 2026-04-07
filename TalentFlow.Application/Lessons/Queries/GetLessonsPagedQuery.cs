using System;
using MediatR;
using TalentFlow.Application.Common.Models;
using TalentFlow.Application.Lessons.DTOs;

namespace TalentFlow.Application.Lessons.Queries
{
    public record GetLessonsPagedQuery(Guid CourseId, int PageNumber, int PageSize)
        : IRequest<PagedResult<LessonDto>>;
}
