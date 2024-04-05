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

    [HttpGet(Router.ClientRouting.GetList)]

    public async Task<IActionResult> GetClientList()
    {
        var response = await _mediator.Send(new GetClientListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ClientRouting.GetListByCompanyID)]

    public async Task<IActionResult> GetClientListByCompanyID([FromRoute] GetClientListByCompanyIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.ClientRouting.GetByID)]
    public async Task<IActionResult> GetClientByID([FromRoute] GetClientByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.ClientRouting.Add)]
    public async Task<IActionResult> AddClient([FromBody] AddClientCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.ClientRouting.Update)]
    public async Task<IActionResult> UpdateClient([FromBody] UpdateClientCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.ClientRouting.Delete)]
    public async Task<IActionResult> DeleteClient([FromRoute] DeleteClientCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
