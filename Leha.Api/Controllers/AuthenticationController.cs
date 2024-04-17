using Leha.Api.BaseController;
using Leha.Core.Features.Authentication.Quaries.Models;
using Leha.Core.Features.Authorization.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class AuthenticationController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpPost(Router.AuthenticationRouting.SignIn)]
    public async Task<IActionResult> SignIn([FromBody] SignInQuery query)
    {
        var response = await _mediator.Send(query);
        return NewResult(response);
    }

    [HttpGet(Router.AuthenticationRouting.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetRoleListQuery());
        return NewResult(response);
    }

    #endregion
}
