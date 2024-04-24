using Leha.Api.BaseController;
using Leha.Core.Features.ProjectPhases.Commands.Models;
using Leha.Core.Features.ProjectPhases.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class ProjectPhaseController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.ProjectPhaseRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetProjectPhaseListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ProjectPhaseRouting.GetAllByProjectId)]

    public async Task<IActionResult> GetAllByProjectID([FromRoute] GetProjectPhaseListByProjectIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.ProjectPhaseRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetProjectPhaseByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpGet(Router.ProjectPhaseRouting.GetDetails)]
    public async Task<IActionResult> GetDetails([FromRoute] GetProjectPhaseDetailsQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }


    [HttpPost(Router.ProjectPhaseRouting.Add)]
    public async Task<IActionResult> Add([FromForm] AddProjectPhaseCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.ProjectPhaseRouting.Update)]
    public async Task<IActionResult> Update([FromForm] UpdateProjectPhaseCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.ProjectPhaseRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteProjectPhaseCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
