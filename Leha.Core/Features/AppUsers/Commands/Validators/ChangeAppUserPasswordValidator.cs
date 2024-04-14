using FluentValidation;
using Leha.Core.Features.AppUsers.Commands.Models;

namespace Leha.Core.Features.AppUsers.Commands.Validators;

public class ChangeAppUserPasswordValidator : AbstractValidator<ChangeAppUserPasswordCommand>
{
    #region Fields

    #endregion

    #region Constructors
    public ChangeAppUserPasswordValidator()
    {
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.Id)
          .NotNull().WithMessage("Required.")
          .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.CurrentPassword)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.NewPassword)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.ConfirmNewPassword)
         .NotNull().WithMessage("Required.")
         .NotEmpty().WithMessage("Can't be empty.")
         .Equal(x => x.ConfirmNewPassword).WithMessage("NewPassword must match ConfirmNewPassword");

    }
    #endregion
}
