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

    [HttpGet(Router.FormRouting.GetList)]

    public async Task<IActionResult> GetFormList()
    {
        var response = await _mediator.Send(new GetFormListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.FormRouting.GetListByJobID)]

    public async Task<IActionResult> GetFormListByJobID([FromRoute] GetFormListByJobIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.FormRouting.GetByID)]
    public async Task<IActionResult> GetFormByID([FromRoute] GetFormByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.FormRouting.Add)]
    public async Task<IActionResult> AddForm([FromBody] AddFormCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.FormRouting.Update)]
    public async Task<IActionResult> UpdateForm([FromBody] UpdateFormCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.FormRouting.Delete)]
    public async Task<IActionResult> DeleteForm([FromRoute] DeleteFormCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
