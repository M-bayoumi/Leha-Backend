using Leha.Api.BaseController;
using Leha.Core.Features.Clients.Commands.Models;
using Leha.Core.Features.Clients.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class ClientController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.ClientRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetClientListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ClientRouting.GetAllByCompanyID)]

    public async Task<IActionResult> GetAllByCompanyID([FromRoute] GetClientListByCompanyIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.ClientRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetClientByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.ClientRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddClientCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.ClientRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateClientCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.ClientRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteClientCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
