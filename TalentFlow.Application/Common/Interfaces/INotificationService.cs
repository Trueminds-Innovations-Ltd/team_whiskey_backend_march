using System;
using System.Threading;
using System.Threading.Tasks;

namespace TalentFlow.Application.Common.Interfaces
{
    public interface INotificationService
    {
        Task SendAsync(NotificationMessage notificationMessage);
        Task SendNotificationAsync(Guid notificationId, CancellationToken cancellationToken = default);
    }
}
