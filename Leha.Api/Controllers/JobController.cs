using Leha.Api.BaseController;
using Leha.Core.Features.Jobs.Commands.Models;
using Leha.Core.Features.Jobs.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class JobController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.JobRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetJobListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.JobRouting.GetAllByCompanyId)]

    public async Task<IActionResult> GetAllByCompanyId([FromRoute] GetJobListByCompanyIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.JobRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetJobByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpGet(Router.JobRouting.GetDetails)]
    public async Task<IActionResult> GetDetails([FromRoute] GetJobDetailsQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPost(Router.JobRouting.Add)]
    public async Task<IActionResult> Add([FromForm] AddJobCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.JobRouting.Update)]
    public async Task<IActionResult> Update([FromForm] UpdateJobCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.JobRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteJobCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
