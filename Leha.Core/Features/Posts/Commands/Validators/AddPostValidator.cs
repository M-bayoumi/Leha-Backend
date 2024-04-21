using FluentValidation;
using Leha.Core.Features.Posts.Commands.Models;
using Leha.Manager.Managers.Posts;

namespace Leha.Core.Features.Posts.Commands.Validators;

public class AddPostValidator : AbstractValidator<AddPostCommand>
{
    #region Fields
    private readonly IPostManager _postManager;

    #endregion

    #region Constructors
    public AddPostValidator(IPostManager postManager)
    {
        _postManager = postManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.ContentAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.ContentEn)
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
