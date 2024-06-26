﻿using FluentValidation;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Manager.Managers.Companies;

namespace Leha.Core.Features.Companies.Commands.Validators;

public class AddCompanyCommandValidator : AbstractValidator<AddCompanyCommand>
{
    private readonly ICompanyManager _companyService;
    #region Fields

    #endregion

    #region Constructors
    public AddCompanyCommandValidator(ICompanyManager companyService)
    {
        _companyService = companyService;
        ApplyValidationRules();
        ApplyCustomValidationRules();
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

        RuleFor(x => x.SloganAr)
          .NotNull().WithMessage("Required.")
          .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.SloganEn)
          .NotNull().WithMessage("Required.")
          .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.Employees)
         .NotNull().WithMessage("Required.")
         .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.Image)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.Email)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.Phone)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.Link)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");
    }

    public void ApplyCustomValidationRules()
    {
        RuleFor(x => x.NameAr)
            .MustAsync(async (Key, CancellationToken) => !await _companyService.IsNameArExist(Key!))
            .WithMessage("Name is exist");

        RuleFor(x => x.NameEn)
            .MustAsync(async (Key, CancellationToken) => !await _companyService.IsNameEnExist(Key!))
            .WithMessage("Name is exist");
    }
    #endregion
}
