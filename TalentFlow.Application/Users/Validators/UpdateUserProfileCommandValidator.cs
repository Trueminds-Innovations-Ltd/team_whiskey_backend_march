using FluentValidation;
using TalentFlow.Application.Users.Commands;

namespace TalentFlow.Application.Users.Validators
{
    public class UpdateUserProfileCommandValidator : AbstractValidator<UpdateUserProfileCommand>
    {
        public UpdateUserProfileCommandValidator()
        {
            RuleFor(x => x.FullName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.UpdatedBy)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
