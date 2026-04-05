using MediatR;
using Microsoft.Extensions.Logging;
using TalentFlow.Application.Assessments.Events;

namespace TalentFlow.Application.Assessments.Handlers
{
    public class AssessmentCreatedHandler : INotificationHandler<AssessmentCreatedNotification>
    {
        private readonly ILogger<AssessmentCreatedHandler> _logger;

        public AssessmentCreatedHandler(ILogger<AssessmentCreatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(AssessmentCreatedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Assessment created: Id={AssessmentId}, OccurredOn={OccurredOn}",
                notification.DomainEvent.Assessment.Id,
                notification.DomainEvent.OccurredOn);

            // TODO: trigger downstream workflows (analytics, audit, etc.)
            return Task.CompletedTask;
        }
    }
}
