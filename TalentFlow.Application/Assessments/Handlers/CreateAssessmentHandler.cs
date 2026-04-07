using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Assessments.Commands;
using TalentFlow.Application.Assessments.DTOs;
using TalentFlow.Domain.Entities;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Assessments.Handlers
{
    public class CreateAssessmentHandler : IRequestHandler<CreateAssessmentCommand, AssessmentDto>
    {
        private readonly IAssessmentRepository _assessmentRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateAssessmentHandler(IAssessmentRepository assessmentRepository, IUnitOfWork unitOfWork)
        {
            _assessmentRepository = assessmentRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<AssessmentDto> Handle(CreateAssessmentCommand request, CancellationToken cancellationToken)
        {
            // Match the entity constructor
            var assessment = new Assessment(request.CourseId, request.Title, request.Instructions);

            await _assessmentRepository.AddAsync(assessment, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

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
                    }).ToList()
            };
        }
    }
}
