using FluentValidation;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Manager.Managers.Companies;

namespace Leha.Core.Features.Companies.Commands.Validators;

public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    private readonly ICompanyManager _companyService;
    #region Fields

    #endregion

    #region Constructors
    public UpdateCompanyCommandValidator(ICompanyManager companyService)
    {
        _companyService = companyService;
        ApplyValidationRules();
        ApplyCustomValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.CompanyName)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");
    }

    public void ApplyCustomValidationRules()
    {
        RuleFor(x => x.CompanyName)
            .MustAsync(async (model, Key, CancellationToken) => !await _companyService.IsNameExistExludeSelf(Key!, model.ID))
            .WithMessage("Already exist");
    }
    #endregion
}
