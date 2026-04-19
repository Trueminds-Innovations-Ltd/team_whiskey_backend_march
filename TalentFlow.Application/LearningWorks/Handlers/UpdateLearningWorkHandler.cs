using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Application.Interfaces;
using TalentFlow.Application.LearningWorks.Commands;
using TalentFlow.Application.LearningWorks.DTOs;
using UpdateLearningWorkCommand = TalentFlow.Application.LearningWorks.DTOs.UpdateLearningWorkCommand;

namespace TalentFlow.Application.LearningWorks.Handlers
{
    public class UpdateLearningWorkHandler : IRequestHandler<UpdateLearningWorkCommand, LearningWorkDto>
    {
        private readonly ILearningWorkRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLearningWorkHandler(ILearningWorkRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LearningWorkDto> Handle(UpdateLearningWorkCommand request, CancellationToken cancellationToken)
        {
            var work = await _repository.GetByIdAsync(request.Id, cancellationToken);
            if (work == null) throw new InvalidOperationException("Work not found.");

            work.Title = request.Title;
            work.Details = request.Details;
            work.DueDate = request.DueDate;
            work.State = request.State;
            work.UpdatedAt = DateTime.UtcNow;

            await _repository.UpdateAsync(work, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return new LearningWorkDto
            {
                Id = work.Id,
                AssignedTo = work.AssignedTo,
                Title = work.Title,
                Details = work.Details,
                DueDate = work.DueDate,
                State = work.State
            };
        }

    }
}
