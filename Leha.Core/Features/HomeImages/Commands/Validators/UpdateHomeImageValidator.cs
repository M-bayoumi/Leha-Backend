using FluentValidation;
using Leha.Core.Features.HomeImages.Commands.Models;
using Leha.Manager.Managers.HomeImages;

namespace Leha.Core.Features.HomeImages.Commands.Validators;

public class UpdateHomeImageValidator : AbstractValidator<UpdateHomeImageCommand>
{
    #region Fields
    private readonly IHomeImageManager _homeImageManager;

    #endregion

    #region Constructors
    public UpdateHomeImageValidator(IHomeImageManager homeImageManager)
    {
        _homeImageManager = homeImageManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.CompanyId)
           .NotNull().WithMessage("Required.")
           .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}