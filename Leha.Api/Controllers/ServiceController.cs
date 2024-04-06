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

    [HttpGet(Router.ServiceRouting.GetList)]

    public async Task<IActionResult> GetServiceList()
    {
        var response = await _mediator.Send(new GetServiceListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ServiceRouting.GetListByCompanyID)]

    public async Task<IActionResult> GetServiceListByCompanyID([FromRoute] GetServiceListByCompanyIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.ServiceRouting.GetByID)]
    public async Task<IActionResult> GetServiceByID([FromRoute] GetServiceByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.ServiceRouting.Add)]
    public async Task<IActionResult> AddService([FromBody] AddServiceCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.ServiceRouting.Update)]
    public async Task<IActionResult> UpdateService([FromBody] UpdateServiceCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.ServiceRouting.Delete)]
    public async Task<IActionResult> DeleteService([FromRoute] DeleteServiceCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
