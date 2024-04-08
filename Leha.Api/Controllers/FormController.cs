using Leha.Api.BaseController;
using Leha.Core.Features.Forms.Commands.Models;
using Leha.Core.Features.Forms.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class FormController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.FormRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetFormListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.FormRouting.GetAllByJobID)]

    public async Task<IActionResult> GetAllByJobID([FromRoute] GetFormListByJobIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.FormRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetFormByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.FormRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddFormCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.FormRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateFormCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.FormRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteFormCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
