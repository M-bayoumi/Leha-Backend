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
        RuleFor(x => x.ID)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.BoardMemberName)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.BoardMemberImage)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.BoardMemberPosition)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");
    }
    #endregion
}
