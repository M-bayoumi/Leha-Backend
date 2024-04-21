using FluentValidation;
using Leha.Core.Features.Products.Commands.Models;
using Leha.Manager.Managers.Products;

namespace Leha.Core.Features.Products.Commands.Validators;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
{
    #region Fields
    private readonly IProductManager _productManager;

    #endregion

    #region Constructors
    public UpdateProductValidator(IProductManager productManager)
    {
        _productManager = productManager;
        ApplyValidationRules();
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