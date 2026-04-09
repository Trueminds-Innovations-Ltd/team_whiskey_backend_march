using MediatR;
using Microsoft.Extensions.Logging;
using TalentFlow.Application.Notifications.Events;
using TalentFlow.Application.Notifications.DTOs;


namespace TalentFlow.Application.Notifications.Handlers
{
    public class NotificationSentEventHandler : INotificationHandler<NotificationSentEvent>
    {
        private readonly ILogger<NotificationSentEventHandler> _logger;

        public NotificationSentEventHandler(ILogger<NotificationSentEventHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(NotificationSentEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Notification sent: Id={NotificationId}, LearnerId={LearnerId}, Message={Message}, OccurredOn={OccurredOn}",
                notification.NotificationId,
                notification.UserId,
                notification.Message,
                notification.OccurredOn);

            // TODO: trigger downstream workflows (analytics, audit, etc.)

            return Task.CompletedTask;
        }
    }
}
