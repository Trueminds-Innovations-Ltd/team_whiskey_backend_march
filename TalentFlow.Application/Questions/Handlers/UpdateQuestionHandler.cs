using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Questions.Commands;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Questions.Handlers
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, bool>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateQuestionHandler(IQuestionRepository questionRepository, IUnitOfWork unitOfWork)
        {
            _questionRepository = questionRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateQuestionCommand request, CancellationToken ct)
        {
            // Load the existing question
            var question = await _questionRepository.GetByIdAsync(request.Id, ct);
            if (question == null)
                return false;

            // Apply updates (assuming your Question entity has these methods)
            question.Update(request.Text, request.Answer);

            // Persist changes
            await _questionRepository.UpdateAsync(question, ct);

            // Commit transaction and publish domain events
            await _unitOfWork.SaveChangesAsync(ct);

            return true;
        }
    }
}
