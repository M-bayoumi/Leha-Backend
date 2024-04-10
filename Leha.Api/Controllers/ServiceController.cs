using Leha.Api.BaseController;
using Leha.Core.Features.Services.Commands.Models;
using Leha.Core.Features.Services.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class ServiceController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.ServiceRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetServiceListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ServiceRouting.GetAllByCompanyId)]

    public async Task<IActionResult> GetAllByCompanyId([FromRoute] GetServiceListByCompanyIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.ServiceRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetServiceByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.ServiceRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddServiceCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.ServiceRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateServiceCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.ServiceRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteServiceCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
