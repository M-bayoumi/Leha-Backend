using Leha.Api.BaseController;
using Leha.Core.Features.AppUsers.Commands.Models;
using Leha.Core.Features.BoardMembers.Commands.Models;
using Leha.Core.Features.BoardMembers.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class AppUserController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.AppUserRouting.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetBoardMemberListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.AppUserRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetBoardMemberByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.AppUserRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddAppUserCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.AppUserRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateBoardMemberCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.AppUserRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteBoardMemberCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
