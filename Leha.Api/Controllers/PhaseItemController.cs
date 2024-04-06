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

    [HttpGet(Router.PhaseItemRouting.GetList)]

    public async Task<IActionResult> GetPhaseItemList()
    {
        var response = await _mediator.Send(new GetPhaseItemListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.PhaseItemRouting.GetListByProjectPhaseID)]

    public async Task<IActionResult> GetPhaseItemListByProjectPhaseID([FromRoute] GetPhaseItemListByProjectPhaseIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.PhaseItemRouting.GetByID)]
    public async Task<IActionResult> GetPhaseItemByID([FromRoute] GetPhaseItemByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.PhaseItemRouting.Add)]
    public async Task<IActionResult> AddPhaseItem([FromBody] AddPhaseItemCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.PhaseItemRouting.Update)]
    public async Task<IActionResult> UpdatePhaseItem([FromBody] UpdatePhaseItemCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.PhaseItemRouting.Delete)]
    public async Task<IActionResult> DeletePhaseItem([FromRoute] DeletePhaseItemCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
