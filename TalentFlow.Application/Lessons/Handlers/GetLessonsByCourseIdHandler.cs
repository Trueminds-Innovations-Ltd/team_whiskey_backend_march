using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Application.Common.Mappings;
using TalentFlow.Application.Lessons.DTOs;
using TalentFlow.Application.Lessons.Queries;

namespace TalentFlow.Application.Lessons.Handlers
{
    public class GetLessonsByCourseIdHandler
        : IRequestHandler<GetLessonsByCourseIdQuery, List<LessonDto>>
    {
        private readonly ILessonRepository _lessonRepository;

        public GetLessonsByCourseIdHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<List<LessonDto>> Handle(
            GetLessonsByCourseIdQuery request,
            CancellationToken cancellationToken)
        {
            var lessons = await _lessonRepository.GetByCourseIdAsync(request.CourseId, cancellationToken);
            return lessons.Select(l => l.ToDto()).ToList();
        }
    }
}
