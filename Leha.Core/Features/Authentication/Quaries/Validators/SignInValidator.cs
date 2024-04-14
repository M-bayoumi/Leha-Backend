using FluentValidation;
using Leha.Core.Features.Authentication.Quaries.Models;

namespace Leha.Core.Features.Authentication.Quaries.Validators;

public class SignInValidator : AbstractValidator<SignInQuery>
{
    #region Fields

    #endregion

    #region Constructors
    public SignInValidator()
    {
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.Email)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.Password)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

    }
    #endregion
}
