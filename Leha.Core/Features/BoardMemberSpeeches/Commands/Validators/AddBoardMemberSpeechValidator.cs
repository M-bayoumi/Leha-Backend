using FluentValidation;
using Leha.Core.Features.BoardMemberSpeeches.Commands.Models;
using Leha.Manager.Managers.BoardMemberSpeeches;

namespace Leha.Core.Features.BoardMemberSpeaches.Commands.Validators;

public class AddBoardMemberSpeechValidator : AbstractValidator<AddBoardMemberSpeechCommand>
{
    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeechManager;

    #endregion

    #region Constructors
    public AddBoardMemberSpeechValidator(IBoardMemberSpeechManager boardMemberSpeechManager)
    {
        _boardMemberSpeechManager = boardMemberSpeechManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
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
