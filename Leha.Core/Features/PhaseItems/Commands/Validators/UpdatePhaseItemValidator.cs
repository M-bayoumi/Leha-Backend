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
        RuleFor(x => x.Id)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.Number)
       .NotNull().WithMessage("Required.")
       .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.NameAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.NameEn)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.AcumulativePercentage)
            .NotNull().WithMessage("Required.")
            .Must(x => x <= 100.00M).WithMessage("Maximum value is 100.00.");

        RuleFor(x => x.ProgressPercentage)
           .NotNull().WithMessage("Required.")
           .Must(x => x <= 100.00M).WithMessage("Maximum value is 100.00.");

        RuleFor(x => x.ExecutionProgressAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.ExecutionProgressEn)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.RFIAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.RFIEn)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.WIRAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.WIREn)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.ScheduleAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.ScheduleEn)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.UnitAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.UnitEn)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.InitialInventoryQuantities)
            .NotNull().WithMessage("Required.");

        RuleFor(x => x.ActualInventoryQuantities)
            .NotNull().WithMessage("Required.");

        RuleFor(x => x.ProjectPhaseId)
           .NotNull().WithMessage("Required.")
           .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}