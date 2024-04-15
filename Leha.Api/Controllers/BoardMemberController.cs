using Leha.Api.BaseController;
using Leha.Core.Features.BoardMembers.Commands.Models;
using Leha.Core.Features.BoardMembers.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
[Authorize(Roles = "Admin, Engineer")]
public class BoardMemberController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.BoardMemberRouting.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetBoardMemberListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.BoardMemberRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetBoardMemberByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.BoardMemberRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddBoardMemberCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.BoardMemberRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateBoardMemberCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.BoardMemberRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteBoardMemberCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
