using FluentValidation;
using Leha.Core.Features.PhaseItems.Commands.Models;
using Leha.Manager.Managers.PhaseItems;

namespace Leha.Core.Features.PhaseItems.Commands.Validators;

public class UpdatePhaseItemValidator : AbstractValidator<UpdatePhaseItemCommand>
{
    #region Fields
    private readonly IPhaseItemManager _phaseItemManager;

    #endregion

    #region Constructors
    public UpdatePhaseItemValidator(IPhaseItemManager phaseItemManager)
    {
        _phaseItemManager = phaseItemManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.ID)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.PhaseItemNumber)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.AcumulativePercentage)
            .NotNull().WithMessage("Required.")
            .Must(x => x <= 100.00M).WithMessage("Maximum value is 100.00.");

        RuleFor(x => x.ProgressPercentage)
            .NotNull().WithMessage("Required.")
            .Must(x => x <= 100.00M).WithMessage("Maximum value is 100.00.");

        RuleFor(x => x.ExecutionProgress)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.RFI)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.WIR)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.Schedule)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.Unit)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.InitialInventoryQuantities)
            .NotNull().WithMessage("Required.");

        RuleFor(x => x.ActualInventoryQuantities)
            .NotNull().WithMessage("Required.");

        RuleFor(x => x.ProjectPhaseID)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}