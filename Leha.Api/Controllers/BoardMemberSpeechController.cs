using Leha.Api.BaseController;
using Leha.Core.Features.BoardMemberSpeeches.Commands.Models;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class BoardMemberSpeechController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.BoardMemberSpeechRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetBoardMemberSpeechListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.BoardMemberSpeechRouting.GetAllByBoardMemberID)]
    public async Task<IActionResult> GetAllByBoardMemberID([FromRoute] GetBoardMemberSpeechesListByBoardMemberIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpGet(Router.BoardMemberSpeechRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetBoardMemberSpeechByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.BoardMemberSpeechRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddBoardMemberSpeechCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut(Router.BoardMemberSpeechRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateBoardMemberSpeechCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete(Router.BoardMemberSpeechRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteBoardMemberSpeachCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
