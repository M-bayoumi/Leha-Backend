using FluentValidation;
using Leha.Core.Features.Authorization.Commands.Models;

namespace Leha.Core.Features.Authorization.Commands.Validators;

public class UpdateRoleValidator : AbstractValidator<UpdateRoleCommand>
{
    #region Fields

    #endregion

    #region Constructors
    public UpdateRoleValidator()
    {
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.Name)
          .NotNull().WithMessage("Required.")
          .NotEmpty().WithMessage("Can't be empty.");
    }
    #endregion
}
