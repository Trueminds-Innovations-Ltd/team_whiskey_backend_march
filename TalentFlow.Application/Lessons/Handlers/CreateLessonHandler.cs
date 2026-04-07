using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Application.Common.Mappings;
using TalentFlow.Application.Lessons.Commands;
using TalentFlow.Application.Lessons.DTOs;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Lessons.Handlers
{
    public class CreateLessonHandler
        : IRequestHandler<CreateLessonCommand, LessonDto>
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLessonHandler(
            ILessonRepository lessonRepository,
            IUnitOfWork unitOfWork)
        {
            _lessonRepository = lessonRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LessonDto> Handle(
            CreateLessonCommand request,
            CancellationToken cancellationToken)
        {
            var lesson = new Lesson(
                request.CourseId,
                request.Title,
                request.Content,
                request.Order,
                request.Duration // ✅ FIXED
            );

            await _lessonRepository.AddAsync(lesson, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return lesson.ToDto();
        }
    }
}