using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Questions.Commands;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Questions.Handlers
{
    public class UpdateQuestionHandler : IRequestHandler<UpdateQuestionCommand, bool>
    {
        private readonly IQuestionRepository _repo;

        public UpdateQuestionHandler(IQuestionRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(UpdateQuestionCommand request, CancellationToken ct)
        {
            var question = await _repo.GetByIdAsync(request.Id, ct);
            if (question == null) return false;

            question.Update(request.Text, request.Answer);
            await _repo.UpdateAsync(question, ct);

            return true;
        }
    }
}
