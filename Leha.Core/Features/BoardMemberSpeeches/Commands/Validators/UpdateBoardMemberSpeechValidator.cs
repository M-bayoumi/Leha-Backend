using FluentValidation;
using Leha.Core.Features.BoardMemberSpeeches.Commands.Models;
using Leha.Manager.Managers.BoardMembers;

namespace Leha.Core.Features.BoardMembers.Commands.Validators;

public class UpdateBoardMemberSpeechValidator : AbstractValidator<UpdateBoardMemberSpeechCommand>
{
    #region Fields
    private readonly IBoardMemberManager _boardMemberManager;

    #endregion

    #region Constructors
    public UpdateBoardMemberSpeechValidator(IBoardMemberManager boardMemberManager)
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

        RuleFor(x => x.ContentAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.ContentEn)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.BoardMemberId)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");


    }
    #endregion
}
