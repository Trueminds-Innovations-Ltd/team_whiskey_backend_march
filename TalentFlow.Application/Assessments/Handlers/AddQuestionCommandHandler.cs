using MediatR;
using TalentFlow.Application.Assessments.Commands;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Assessments.Handlers
{
    public class AddQuestionCommandHandler : IRequestHandler<AddQuestionCommand, bool>
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddQuestionCommandHandler(IAssessmentRepository assessmentRepository, IUnitOfWork unitOfWork)
        {
            _assessmentRepository = assessmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(AddQuestionCommand request, CancellationToken cancellationToken)
        {
            var assessment = await _assessmentRepository.GetByIdAsync(request.AssessmentId, cancellationToken);
            if (assessment == null) return false;

            assessment.AddQuestion(request.Text, request.Answer);

            await _assessmentRepository.UpdateAsync(assessment, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
