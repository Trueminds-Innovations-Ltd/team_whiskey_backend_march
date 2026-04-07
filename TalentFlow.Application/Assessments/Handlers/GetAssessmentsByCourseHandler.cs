using System.Linq;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Assessments.DTOs;
using TalentFlow.Application.Assessments.Queries;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Assessments.Handlers
{
    public class GetAssessmentsByCourseHandler
        : IRequestHandler<GetAssessmentsByCourseQuery, List<AssessmentDto>>
    {
        private readonly IAssessmentRepository _repo;

        public GetAssessmentsByCourseHandler(IAssessmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<AssessmentDto>> Handle(GetAssessmentsByCourseQuery request, CancellationToken ct)
        {
            var assessments = await _repo.GetByCourseIdAsync(request.CourseId, ct);
            if (assessments == null || !assessments.Any()) return new List<AssessmentDto>();

            return assessments.Select(a => new AssessmentDto
            {
                Id = a.Id,
                Title = a.Title,
                Instructions = a.Instructions,
                CreatedAt = a.CreatedAt,
                Questions = a.Questions.Select(q => new QuestionDto
                {
                    Id = q.Id,
                    Text = q.Text,
                    Answer = q.Answer
                }).ToList()
            }).ToList();
        }
    }
}
