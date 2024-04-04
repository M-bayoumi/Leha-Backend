using Leha.Api.BaseController;
using Leha.Core.Features.BoardMembers.Commands.Models;
using Leha.Core.Features.BoardMembers.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class BoardMemberController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.BoardMemberRouting.GetList)]

    public async Task<IActionResult> GetBoardMemberList()
    {
        var response = await _mediator.Send(new GetBoardMemberListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.BoardMemberRouting.GetByID)]
    public async Task<IActionResult> GetBoardMemberByID([FromRoute] GetBoardMemberByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.BoardMemberRouting.Add)]
    public async Task<IActionResult> AddBoardMember([FromBody] AddBoardMemberCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.BoardMemberRouting.Update)]
    public async Task<IActionResult> UpdateBoardMember([FromBody] UpdateBoardMemberCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.BoardMemberRouting.Delete)]
    public async Task<IActionResult> DeleteBoardMember([FromRoute] DeleteBoardMemberCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
