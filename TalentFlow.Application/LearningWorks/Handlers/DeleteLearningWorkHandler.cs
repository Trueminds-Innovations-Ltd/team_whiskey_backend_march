using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Application.Interfaces;
using TalentFlow.Application.LearningWorks.Commands;

namespace TalentFlow.Application.LearningWorks.Handlers
{
    public class DeleteLearningWorkHandler : IRequestHandler<DeleteLearningWorkCommand, bool>
    {
        private readonly ILearningWorkRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLearningWorkHandler(ILearningWorkRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(DeleteLearningWorkCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
