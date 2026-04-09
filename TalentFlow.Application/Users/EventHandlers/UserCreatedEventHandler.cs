using MediatR;
using TalentFlow.Application.Users.Events;
using TalentFlow.Application.Common.Interfaces;

namespace TalentFlow.Application.Users.EventHandlers
{
    public class UserCreatedEventHandler : INotificationHandler<UserCreatedNotification>
    {
        private readonly INotificationService _notificationService;
        private readonly IEventStreamPublisher _eventStream;

        public UserCreatedEventHandler(INotificationService notificationService, IEventStreamPublisher eventStream)
        {
            _notificationService = notificationService;
            _eventStream = eventStream;
        }

        public async Task Handle(UserCreatedNotification notification, CancellationToken cancellationToken)
        {
            var user = notification.DomainEvent.User;

            // Send welcome notification using UserId (the FK)
            await _notificationService.SendAsync(new NotificationMessage
            {
                UserId = user.Id,   // ✅ use the primary key
                DeepLinkUrl = "/me/profile",
                Message = $"Welcome {user.FullName}! Your account has been created."
            });

            // Publish to event stream
            await _eventStream.PublishAsync("UserCreated", new
            {
                user_id = user.Id.ToString(),   // ✅ consistent with FK
                email = user.Email,
                name = user.FullName,
                created_at = DateTime.UtcNow
            }, cancellationToken);
        }
    }
}
