using FluentValidation;
using Leha.Core.Features.BoardMembers.Commands.Models;
using Leha.Manager.Managers.BoardMembers;

namespace Leha.Core.Features.BoardMembers.Commands.Validators;

public class UpdateBoardMemberValidator : AbstractValidator<UpdateBoardMemberCommand>
{
    #region Fields
    private readonly IBoardMemberManager _boardMemberManager;

    #endregion

    #region Constructors
    public UpdateBoardMemberValidator(IBoardMemberManager boardMemberManager)
    {
        _boardMemberManager = boardMemberManager;
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

        RuleFor(x => x.Image)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.PositionAr)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.PositionEn)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");
    }
    #endregion
}
