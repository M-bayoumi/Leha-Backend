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
        RuleFor(x => x.ID)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.ProductName)
              .NotNull().WithMessage("Required.")
              .NotEmpty().WithMessage("Can't be empty.")
              .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.ProductDescription)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.ProductImage)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.CompanyID)
         .NotNull().WithMessage("Required.")
         .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}