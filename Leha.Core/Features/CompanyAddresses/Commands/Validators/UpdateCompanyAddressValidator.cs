using FluentValidation;
using Leha.Core.Features.CompanyAddresses.Commands.Models;
using Leha.Manager.Managers.CompanyAddresses;

namespace Leha.Core.Features.CompanyAddresses.Commands.Validators;

public class UpdateCompanyAddressValidator : AbstractValidator<UpdateCompanyAddressCommand>
{
    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;

    #endregion

    #region Constructors
    public UpdateCompanyAddressValidator(ICompanyAddressManager companyAddressManager)
    {
        _companyAddressManager = companyAddressManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.ID)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.Address)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.CompanyID)
           .NotNull().WithMessage("Required.")
           .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}