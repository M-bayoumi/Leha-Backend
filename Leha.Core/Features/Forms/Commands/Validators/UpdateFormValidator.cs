using FluentValidation;
using Leha.Core.Features.Forms.Commands.Models;
using Leha.Manager.Managers.Forms;

namespace Leha.Core.Features.Forms.Commands.Validators;

public class UpdateFormValidator : AbstractValidator<UpdateFormCommand>
{
    #region Fields
    private readonly IFormManager _formManager;

    #endregion

    #region Constructors
    public UpdateFormValidator(IFormManager formManager)
    {
        _formManager = formManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.ID)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.FormFullName)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.FormAddress)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.FormJobTitle)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.FormCV)
         .NotNull().WithMessage("Required.")
         .NotEmpty().WithMessage("Can't be empty.")
         .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.JobID)
         .NotNull().WithMessage("Required.")
         .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}