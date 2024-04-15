using Leha.Core.BaseResponse;
using Leha.Core.Features.Authentication.Quaries.Models;
using Leha.Core.Resources;
using Leha.Data.Entities.Identity;
using Leha.Manager.Managers.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Authentication.Quaries.Handlers;

public class SignInQueryHandler : ResponseHandler, IRequestHandler<SignInQuery, Response<string>>
{

    #region Fields
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;
    private readonly IAuthenticationManager _authenticationManager;

    #endregion

    #region Constructors
    public SignInQueryHandler(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IAuthenticationManager authenticationManager,
        IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _authenticationManager = authenticationManager;
    }

    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(SignInQuery request, CancellationToken cancellationToken)
    {
        var dm = await _userManager.FindByEmailAsync(request.Email);
        if (dm == null) return BadRequest<string>();

        var signInResult = _signInManager.CheckPasswordSignInAsync(dm, request.Password, false);
        if (!signInResult.IsCompletedSuccessfully) return BadRequest<string>();
        var result = _authenticationManager.GenerateJwtToken(dm);
        return Success(result);
    }

    #endregion
}
