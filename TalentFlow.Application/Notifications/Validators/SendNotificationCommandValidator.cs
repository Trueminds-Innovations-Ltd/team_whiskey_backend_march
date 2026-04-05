using FluentValidation;
using TalentFlow.Application.Notifications.Commands;

namespace TalentFlow.Application.Notifications.Validators
{
    public class SendNotificationCommandValidator : AbstractValidator<SendNotificationCommand>
    {
        public SendNotificationCommandValidator()
        {
            RuleFor(n => n.UserId)
                .NotEmpty().WithMessage("UserId is required");

            RuleFor(n => n.Message)
                .NotEmpty().WithMessage("Message is required")
                .MaximumLength(500).WithMessage("Message must be less than 500 characters");
        }
    }
}
