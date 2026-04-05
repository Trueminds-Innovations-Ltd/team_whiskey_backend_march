using MediatR;
using Microsoft.Extensions.Logging;
using TalentFlow.Application.Assessments.Events;

namespace TalentFlow.Application.Assessments.Handlers
{
    public class QuestionAddedHandler : INotificationHandler<QuestionAddedNotification>
    {
        private readonly ILogger<QuestionAddedHandler> _logger;

        public QuestionAddedHandler(ILogger<QuestionAddedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(QuestionAddedNotification notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "Question added: QuestionId={QuestionId}, AssessmentId={AssessmentId}, OccurredOn={OccurredOn}",
                notification.DomainEvent.Question.Id,
                notification.DomainEvent.Assessment.Id,
                notification.DomainEvent.OccurredOn);

            // TODO: trigger downstream workflows (grading, analytics, etc.)
            return Task.CompletedTask;
        }
    }
}
