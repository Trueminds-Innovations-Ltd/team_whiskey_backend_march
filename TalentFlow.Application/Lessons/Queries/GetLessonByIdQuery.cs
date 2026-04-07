using System;
using MediatR;
using TalentFlow.Application.Lessons.DTOs;

namespace TalentFlow.Application.Lessons.Queries
{
    public record GetLessonByIdQuery(Guid LessonId) : IRequest<LessonDto?>;
}
