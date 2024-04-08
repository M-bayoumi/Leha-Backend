using Leha.Api.BaseController;
using Leha.Core.Features.HomeImages.Commands.Models;
using Leha.Core.Features.HomeImages.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class HomeImageController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.HomeImageRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetHomeImageListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.HomeImageRouting.GetAllByCompanyID)]

    public async Task<IActionResult> GetAllByCompanyID([FromRoute] GetHomeImageListByCompanyIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.HomeImageRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetHomeImageByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.HomeImageRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddHomeImageCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.HomeImageRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateHomeImageCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.HomeImageRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteHomeImageCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
