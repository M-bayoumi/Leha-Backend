using FluentValidation;
using Leha.Core.Features.Clients.Commands.Models;
using Leha.Manager.Managers.Clients;

namespace Leha.Core.Features.Clients.Commands.Validators;

public class UpdateClientValidator : AbstractValidator<UpdateClientCommand>
{
    #region Fields
    private readonly IClientManager _clientManager;

    #endregion

    #region Constructors
    public UpdateClientValidator(IClientManager clientManager)
    {
        _clientManager = clientManager;
        ApplyValidationRules();
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.ID)
            .NotNull().WithMessage("Required.")
            .GreaterThanOrEqualTo(1).WithMessage("Not Found");

        RuleFor(x => x.ClientName)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.")
            .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.ClientImage)
           .NotNull().WithMessage("Required.")
           .NotEmpty().WithMessage("Can't be empty.")
           .MinimumLength(3).WithMessage("Minimum length is 3 char.");

        RuleFor(x => x.CompanyID)
           .NotNull().WithMessage("Required.")
           .GreaterThanOrEqualTo(1).WithMessage("Not Found");
    }
    #endregion
}