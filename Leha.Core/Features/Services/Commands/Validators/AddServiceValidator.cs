using FluentValidation;
using Leha.Core.Features.Services.Commands.Models;
using Leha.Manager.Managers.Services;

namespace Leha.Core.Features.Services.Commands.Validators;

public class AddServiceValidator : AbstractValidator<AddServiceCommand>
{
    #region Fields
    private readonly IServiceManager _serviceManager;

    #endregion

    #region Constructors
    public AddServiceValidator(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.NameAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.NameEn)
          .NotNull().WithMessage("Required.")
          .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.DescriptionAr)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.DescriptionEn)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.Image)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.CompanyId)
         .NotNull().WithMessage("Required.")
         .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}
