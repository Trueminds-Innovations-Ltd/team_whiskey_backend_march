using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Application.Common.Mappings;
using TalentFlow.Application.Common.Models;
using TalentFlow.Application.Lessons.DTOs;
using TalentFlow.Application.Lessons.Queries;

namespace TalentFlow.Application.Lessons.Handlers
{
    public class GetLessonsPagedHandler
        : IRequestHandler<GetLessonsPagedQuery, PagedResult<LessonDto>>
    {
        private readonly ILessonRepository _lessonRepository;

        public GetLessonsPagedHandler(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public async Task<PagedResult<LessonDto>> Handle(
            GetLessonsPagedQuery request,
            CancellationToken cancellationToken)
        {
            var (items, totalCount) = await _lessonRepository.GetPagedAsync(
                request.PageNumber, request.PageSize, cancellationToken);

            var dtos = items.Select(l => l.ToDto()).ToList();

            return new PagedResult<LessonDto>(dtos, totalCount, request.PageNumber, request.PageSize);
        }
    }
}
