using FluentValidation;
using Leha.Core.Features.HomeImages.Commands.Models;
using Leha.Manager.Managers.HomeImages;

namespace Leha.Core.Features.HomeImages.Commands.Validators;

public class AddHomeImageValidator : AbstractValidator<AddHomeImageCommand>
{
    #region Fields
    private readonly IHomeImageManager _homeImageManager;

    #endregion

    #region Constructors
    public AddHomeImageValidator(IHomeImageManager homeImageManager)
    {
        _homeImageManager = homeImageManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {

        RuleFor(x => x.CompanyId)
        .NotNull().WithMessage("Required.")
        .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}
