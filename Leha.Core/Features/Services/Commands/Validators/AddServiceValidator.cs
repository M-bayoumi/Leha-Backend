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
        RuleFor(x => x.ServiceName)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.ServiceDescription)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.ServiceImage)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.CompanyID)
         .NotNull().WithMessage("Required.")
         .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}
