using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Assessments.DTOs;
using TalentFlow.Application.Assessments.Queries;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Assessments.Handlers
{
    public class GetAssessmentHandler : IRequestHandler<GetAssessmentQuery, AssessmentDto?>
    {
        private readonly IAssessmentRepository _repo;

        public GetAssessmentHandler(IAssessmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<AssessmentDto?> Handle(GetAssessmentQuery request, CancellationToken ct)
        {
            var assessment = await _repo.GetByIdAsync(request.Id, ct);
            if (assessment == null) return null;

            return new AssessmentDto
            {
                Id = assessment.Id,
                Title = assessment.Title,
                Instructions = assessment.Instructions,
                CreatedAt = assessment.CreatedAt,
                Questions = assessment.Questions
                    .Select(q => new QuestionDto
                    {
                        Id = q.Id,
                        Text = q.Text,
                        Answer = q.Answer
                    })
                    .ToList(),
                // Audit fields if you want them here too
                // UpdatedBy = assessment.UpdatedBy,
                // UpdatedAt = assessment.UpdatedAt,
                // DeletedBy = assessment.DeletedBy,
                // DeletedAt = assessment.DeletedAt,
                // IsDeleted = assessment.IsDeleted
            };
        }
    }
}
