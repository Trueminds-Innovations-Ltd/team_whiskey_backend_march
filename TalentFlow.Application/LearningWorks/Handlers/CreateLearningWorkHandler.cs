using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Application.Interfaces;
using TalentFlow.Application.LearningWorks.Commands;
using TalentFlow.Application.LearningWorks.DTOs;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.LearningWorks.Handlers
{
    public class CreateLearningWorkHandler : IRequestHandler<CreateLearningWorkCommand, LearningWorkDto>
    {
        private readonly ILearningWorkRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateLearningWorkHandler(ILearningWorkRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<LearningWorkDto> Handle(CreateLearningWorkCommand request, CancellationToken cancellationToken)
        {
            var work = new LearningWork
            {
                Id = Guid.NewGuid(),
                AssignedTo = request.AssignedTo,
                Title = request.Title,
                Details = request.Details,
                DueDate = request.DueDate,
                State = LearningWorkState.Pending,
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(work, cancellationToken);
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
