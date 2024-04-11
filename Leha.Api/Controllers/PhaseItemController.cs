using Leha.Api.BaseController;
using Leha.Core.Features.PhaseItems.Commands.Models;
using Leha.Core.Features.PhaseItems.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class PhaseItemController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.PhaseItemRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetPhaseItemListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.PhaseItemRouting.GetAllByProjectPhaseId)]

    public async Task<IActionResult> GetAllByProjectPhaseID([FromRoute] GetPhaseItemListByProjectPhaseIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.PhaseItemRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetPhaseItemByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.PhaseItemRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddPhaseItemCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.PhaseItemRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdatePhaseItemCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.PhaseItemRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeletePhaseItemCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
