using FluentValidation;
using Leha.Core.Features.Jobs.Commands.Models;
using Leha.Manager.Managers.Jobs;

namespace Leha.Core.Features.Jobs.Commands.Validators;

public class AddJobValidator : AbstractValidator<AddJobCommand>
{
    #region Fields
    private readonly IJobManager _jobManager;

    #endregion

    #region Constructors
    public AddJobValidator(IJobManager jobManager)
    {
        _jobManager = jobManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.JobTitle)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.JobDescription)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.JobAverageSalary)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.CompanyID)
         .NotNull().WithMessage("Required.")
         .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}
