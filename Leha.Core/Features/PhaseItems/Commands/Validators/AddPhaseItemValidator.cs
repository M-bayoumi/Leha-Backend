using FluentValidation;
using Leha.Core.Features.PhaseItems.Commands.Models;
using Leha.Manager.Managers.PhaseItems;

namespace Leha.Core.Features.PhaseItems.Commands.Validators;

public class AddPhaseItemValidator : AbstractValidator<AddPhaseItemCommand>
{
    #region Fields
    private readonly IPhaseItemManager _phaseItemManager;

    #endregion

    #region Constructors
    public AddPhaseItemValidator(IPhaseItemManager phaseItemManager)
    {
        _phaseItemManager = phaseItemManager;
        ApplyValidationRules();
    }
    #endregion
    #region Handle Functions
    public void ApplyValidationRules()
    {


    }
    #endregion
}
