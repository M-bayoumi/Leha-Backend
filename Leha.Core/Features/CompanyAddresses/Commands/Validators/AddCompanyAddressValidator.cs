using FluentValidation;
using Leha.Core.Features.CompanyAddresses.Commands.Models;
using Leha.Manager.Managers.CompanyAddresses;

namespace Leha.Core.Features.CompanyAddresses.Commands.Validators;

public class AddCompanyAddressValidator : AbstractValidator<AddCompanyAddressCommand>
{
    #region Fields
    private readonly ICompanyAddressManager _companyAddressManager;
    #endregion

    #region Constructors
    public AddCompanyAddressValidator(ICompanyAddressManager companyAddressManager)
    {
        _companyAddressManager = companyAddressManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.AddressAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.AddressEn)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.CompanyId)
        .NotNull().WithMessage("Required.")
        .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}
