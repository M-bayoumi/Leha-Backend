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
        RuleFor(x => x.TitleAr)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.TitleEn)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.DescriptionAr)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.DescriptionEn)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.AverageSalary)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.");

        RuleFor(x => x.CompanyId)
         .NotNull().WithMessage("Required.")
         .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}
