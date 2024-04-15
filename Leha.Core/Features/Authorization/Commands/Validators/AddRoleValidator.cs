using FluentValidation;
using Leha.Core.Features.Authorization.Commands.Models;
using Leha.Manager.Managers.Authorization;

namespace Leha.Core.Features.Authorization.Commands.Validators;

public class AddRoleValidator : AbstractValidator<AddRoleCommand>
{
    #region Fields
    private readonly IAuthorizationManager _authorizationManager;
    #endregion

    #region Constructors
    public AddRoleValidator(IAuthorizationManager authorizationManager)
    {
        ApplyValidationRules();
        ApplyCustomValidationRules();
        _authorizationManager = authorizationManager;
    }
    #endregion

    #region Handle Functions
    public void ApplyValidationRules()
    {
        RuleFor(x => x.Name)
            .NotNull().WithMessage("Required.")
            .NotEmpty().WithMessage("Can't be empty.");

    }
    public void ApplyCustomValidationRules()
    {
        RuleFor(x => x.Name)
            .MustAsync(async (Key, CancellationToken) => !await _authorizationManager.IsRoleExist(Key))
            .WithMessage("Name is exist");

    }
    #endregion
}
