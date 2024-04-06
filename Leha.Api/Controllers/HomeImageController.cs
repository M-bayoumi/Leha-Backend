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

    [HttpGet(Router.HomeImageRouting.GetList)]

    public async Task<IActionResult> GetHomeImageList()
    {
        var response = await _mediator.Send(new GetHomeImageListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.HomeImageRouting.GetListByCompanyID)]

    public async Task<IActionResult> GetHomeImageListByCompanyID([FromRoute] GetHomeImageListByCompanyIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.HomeImageRouting.GetByID)]
    public async Task<IActionResult> GetHomeImageByID([FromRoute] GetHomeImageByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.HomeImageRouting.Add)]
    public async Task<IActionResult> AddHomeImage([FromBody] AddHomeImageCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.HomeImageRouting.Update)]
    public async Task<IActionResult> UpdateHomeImage([FromBody] UpdateHomeImageCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.HomeImageRouting.Delete)]
    public async Task<IActionResult> DeleteHomeImage([FromRoute] DeleteHomeImageCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
