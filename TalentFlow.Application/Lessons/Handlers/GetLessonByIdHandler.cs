using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Lessons.DTOs;
using TalentFlow.Application.Lessons.Queries;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Application.Common.Mappings;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Lessons.Handlers
{
    public class GetLessonByIdHandler : IRequestHandler<GetLessonByIdQuery, LessonDto?>
    {
        private readonly ILessonRepository _lessonRepository;

        public GetLessonByIdHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<LessonDto?> Handle(GetLessonByIdQuery request, CancellationToken cancellationToken)
        {
            var lesson = await _lessonRepository.GetByIdAsync(request.LessonId, cancellationToken);

            if (lesson == null)
                return null;

            // Manual mapping using extension method
            return lesson.ToDto();
        }
    }
}
