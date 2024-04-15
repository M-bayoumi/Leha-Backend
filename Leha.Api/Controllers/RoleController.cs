using Leha.Api.BaseController;
using Leha.Core.Features.Authorization.Commands.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class RoleController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpPost(Router.AuthorizationRouting.Create)]
    public async Task<IActionResult> SignIn([FromBody] AddRoleCommand query)
    {
        var response = await _mediator.Send(query);
        return NewResult(response);
    }

    #endregion
}
