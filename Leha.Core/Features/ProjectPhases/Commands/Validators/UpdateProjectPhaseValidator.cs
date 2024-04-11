using FluentValidation;
using Leha.Core.Features.ProjectPhases.Commands.Models;
using Leha.Manager.Managers.ProjectPhases;

namespace Leha.Core.Features.ProjectPhases.Commands.Validators;

public class UpdateProjectPhaseValidator : AbstractValidator<UpdateProjectPhaseCommand>
{
    #region Fields
    private readonly IProjectPhaseManager _projectPhaseManager;

    #endregion

    #region Constructors
    public UpdateProjectPhaseValidator(IProjectPhaseManager projectPhaseManager)
    {
        _projectPhaseManager = projectPhaseManager;
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
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.NameEn)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.ProjectId)
         .NotNull().WithMessage("Required.")
         .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}