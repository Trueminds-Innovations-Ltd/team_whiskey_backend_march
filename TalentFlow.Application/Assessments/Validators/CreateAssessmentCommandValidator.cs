using FluentValidation;
using TalentFlow.Application.Assessments.Commands;

namespace TalentFlow.Application.Assessments.Validators
{
    public class CreateAssessmentCommandValidator : AbstractValidator<CreateAssessmentCommand>
    {
        public CreateAssessmentCommandValidator()
        {
            RuleFor(a => a.Title)
                .NotEmpty().WithMessage("Assessment title is required")
                .MaximumLength(200).WithMessage("Title must be less than 200 characters");

            RuleFor(a => a.Instructions)
                .NotEmpty().WithMessage("Instructions are required")
                .MaximumLength(2000).WithMessage("Instructions must be less than 2000 characters");
        }
    }
}
