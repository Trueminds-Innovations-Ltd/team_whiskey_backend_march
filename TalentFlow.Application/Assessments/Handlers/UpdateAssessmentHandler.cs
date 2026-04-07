using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Assessments.Commands;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Assessments.Handlers
{
    public class UpdateAssessmentHandler : IRequestHandler<UpdateAssessmentCommand, bool>
    {
        private readonly IAssessmentRepository _repo;

        public UpdateAssessmentHandler(IAssessmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateAssessmentCommand request, CancellationToken ct)
        {
            var assessment = await _repo.GetByIdAsync(request.Id, ct);
            if (assessment == null) return false;

            // Update fields
            assessment.UpdateDetails(request.Title, request.Description, request.UpdatedBy);

            await _repo.UpdateAsync(assessment, ct);
            return true;
        }
    }
}
