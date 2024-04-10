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
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.FullNameAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.FullNameEn)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.AddressAr)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.AddressEn)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.JobTitleAr)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.JobTitleEn)
          .NotNull().WithMessage("Required.")
          .NotEmpty().WithMessage("Can't be empty.")
          .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.CV)
          .NotNull().WithMessage("Required.")
          .NotEmpty().WithMessage("Can't be empty.")
          .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.JobId)
          .NotNull().WithMessage("Required.")
          .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}