using FluentValidation;
using Leha.Core.Features.Posts.Commands.Models;
using Leha.Manager.Managers.Posts;

namespace Leha.Core.Features.Posts.Commands.Validators;

public class UpdatePostValidator : AbstractValidator<UpdatePostCommand>
{
    #region Fields
    private readonly IPostManager _postManager;

    #endregion

    #region Constructors
    public UpdatePostValidator(IPostManager postManager)
    {
        _postManager = postManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.ID)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.PostContent)
              .NotNull().WithMessage("Required.")
              .NotEmpty().WithMessage("Can't be empty.")
              .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.PostImage)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.CompanyID)
         .NotNull().WithMessage("Required.")
         .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}