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

    [HttpGet(Router.BoardMemberSpeechRouting.GetList)]

    public async Task<IActionResult> GetBoardMemberSpeechList()
    {
        var response = await _mediator.Send(new GetBoardMemberSpeechListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.BoardMemberSpeechRouting.GetByID)]
    public async Task<IActionResult> GetBoardMemberSpeechByID([FromRoute] GetBoardMemberSpeechByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.BoardMemberSpeechRouting.Add)]
    public async Task<IActionResult> AddBoardMemberSpeech([FromBody] AddBoardMemberSpeechCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.BoardMemberSpeechRouting.Update)]
    public async Task<IActionResult> UpdateBoardMemberSpeech([FromBody] UpdateBoardMemberSpeechCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.BoardMemberSpeechRouting.Delete)]
    public async Task<IActionResult> DeleteBoardMemberSpeech([FromRoute] DeleteBoardMemberSpeachCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
