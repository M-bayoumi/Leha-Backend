using FluentValidation;
using Leha.Core.Features.AppUsers.Commands.Models;

namespace Leha.Core.Features.AppUsers.Commands.Validators;

public class UpdateAppUserValidator : AbstractValidator<UpdateAppUserCommand>
{
    #region Fields

    #endregion

    #region Constructors
    public UpdateAppUserValidator()
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

        RuleFor(x => x.FullName)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.UserName)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.Email)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.PhoneNumber)
        .NotNull().WithMessage("Required.")
        .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.Address)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");
    }
    #endregion
}
