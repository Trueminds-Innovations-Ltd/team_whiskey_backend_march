using FluentValidation;
using TalentFlow.Application.Instructors.Commands;

namespace TalentFlow.Application.Instructors.Validators
{
    public class CreateInstructorCommandValidator : AbstractValidator<CreateInstructorCommand>
    {
        public CreateInstructorCommandValidator()
        {
            RuleFor(i => i.FullName)
                .NotEmpty().WithMessage("Instructor name is required")
                .MaximumLength(200).WithMessage("Name must be less than 200 characters");

            RuleFor(i => i.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(i => i.Bio)
                .MaximumLength(1000).WithMessage("Bio must be less than 1000 characters");
        }
    }
}
