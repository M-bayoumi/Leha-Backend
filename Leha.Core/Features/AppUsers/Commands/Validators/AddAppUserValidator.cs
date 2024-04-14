using FluentValidation;
using Leha.Core.Features.AppUsers.Commands.Models;

namespace Leha.Core.Features.AppUsers.Commands.Validators;

public class AddAppUserValidator : AbstractValidator<AddAppUserCommand>
{
    #region Fields

    #endregion

    #region Constructors
    public AddAppUserValidator()
    {
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.FullName)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.UserName)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.Email)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.Password)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .Equal(x => x.Password).WithMessage("Password must matche confirmPassword");

        RuleFor(x => x.ConfirmPassword)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.Address)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");
    }
    #endregion
}
