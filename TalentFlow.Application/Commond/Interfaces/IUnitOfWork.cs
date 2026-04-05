namespace TalentFlow.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public interface IEventStreamPublisher
    {
        Task PublishAsync(string eventName, object payload, CancellationToken cancellationToken = default);
    }

    public interface IJwtTokenService
    {
        string GenerateToken(string learnerId, string email);
    }

    public interface INotificationService
    {
        Task SendAsync(NotificationMessage notificationMessage);
        Task SendNotificationAsync(Guid notificationId, CancellationToken cancellationToken = default);
    }
}

public class NotificationMessage
{
    public string LearnerId { get; set; } = string.Empty;
    public string DeepLinkUrl { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}
