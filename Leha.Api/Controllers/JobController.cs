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

    [HttpGet(Router.JobRouting.GetList)]

    public async Task<IActionResult> GetJobList()
    {
        var response = await _mediator.Send(new GetJobListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.JobRouting.GetListByCompanyID)]

    public async Task<IActionResult> GetJobListByCompanyID([FromRoute] GetJobListByCompanyIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.JobRouting.GetByID)]
    public async Task<IActionResult> GetJobByID([FromRoute] GetJobByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.JobRouting.Add)]
    public async Task<IActionResult> AddJob([FromBody] AddJobCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.JobRouting.Update)]
    public async Task<IActionResult> UpdateJob([FromBody] UpdateJobCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.JobRouting.Delete)]
    public async Task<IActionResult> DeleteJob([FromRoute] DeleteJobCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
