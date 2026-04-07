using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TalentFlow.Application.Notifications.Commands;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Notifications.Handlers
{
    public class DeleteNotificationHandler : IRequestHandler<DeleteNotificationCommand, bool>
    {
        private readonly INotificationRepository _repo;

        public DeleteNotificationHandler(INotificationRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DeleteNotificationCommand request, CancellationToken ct)
        {
            var notification = await _repo.GetByIdAsync(request.Id, ct);
            if (notification == null) return false;

            // Just call SoftDelete, no assignment
            notification.SoftDelete(request.DeletedBy);

            await _repo.UpdateAsync(notification, ct);

            return true;
        }
    }
}
