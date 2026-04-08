using MediatR;
using TalentFlow.Application.Common.Interfaces;
using TalentFlow.Application.Users.Commands;
using TalentFlow.Domain.Entities;

namespace TalentFlow.Application.Users.Handlers
{
    public class UpdateUserProfileHandler : IRequestHandler<UpdateUserProfileCommand, bool>
    {
        private readonly IUserRepository _repository;

        public UpdateUserProfileHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByLearnerIdAsync(request.LearnerId, cancellationToken);
            if (user == null) return false;

            // ✅ Now compiles, properties exist on the command
            user.UpdateProfile(request.FullName, request.Email, request.UpdatedBy);

            await _repository.UpdateAsync(user, cancellationToken);
            return true;
        }
    }
}
