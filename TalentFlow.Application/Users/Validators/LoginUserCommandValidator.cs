using FluentValidation;
using TalentFlow.Application.Users.Commands;

namespace TalentFlow.Application.Users.Validators
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(u => u.LearnerId)
                .NotEmpty().WithMessage("LearnerId is required")
                .Matches("^[a-zA-Z0-9_-]+$").WithMessage("LearnerId must be alphanumeric");

            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");
        }
    }
}
