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
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.NameAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.NameEn)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.SloganAr)
        .NotNull().WithMessage("Required.")
        .NotEmpty().WithMessage("Can't be empty.")
        .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.SloganEn)
          .NotNull().WithMessage("Required.")
          .NotEmpty().WithMessage("Can't be empty.")
          .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.Employees)
         .NotNull().WithMessage("Required.")
         .NotEmpty().WithMessage("Can't be empty.")
         .GreaterThanOrEqualTo(2).WithMessage("CompanyEmployees must be greater than or equal 2.");

        RuleFor(x => x.Image)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.Email)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.Phone)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.Link)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");
    }

    public void ApplyCustomValidationRules()
    {
        RuleFor(x => x.NameAr)
            .MustAsync(async (model, Key, CancellationToken) => !await _companyService.IsNameArExistExludeSelf(Key!, model.Id))
            .WithMessage("Already exist");

        RuleFor(x => x.NameEn)
         .MustAsync(async (model, Key, CancellationToken) => !await _companyService.IsNameEnExistExludeSelf(Key!, model.Id))
         .WithMessage("Already exist");
    }
    #endregion
}
