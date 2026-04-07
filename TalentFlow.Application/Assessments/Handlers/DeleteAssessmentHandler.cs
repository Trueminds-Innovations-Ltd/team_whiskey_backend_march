using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Assessments.Commands;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Assessments.Handlers
{
    public class DeleteAssessmentHandler : IRequestHandler<DeleteAssessmentCommand, bool>
    {
        private readonly IAssessmentRepository _repo;

        public DeleteAssessmentHandler(IAssessmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteAssessmentCommand request, CancellationToken ct)
        {
            var assessment = await _repo.GetByIdAsync(request.Id, ct);
            if (assessment == null) return false;

            // Mark deleted with audit info
            assessment.SoftDelete(request.DeletedBy);

            await _repo.UpdateAsync(assessment, ct);
            return true;
        }
    }
}
