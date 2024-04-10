using Leha.Api.BaseController;
using Leha.Core.Features.Projects.Commands.Models;
using Leha.Core.Features.Projects.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class ProjectController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.ProjectRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetProjectListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ProjectRouting.GetAllByCompanyId)]
    public async Task<IActionResult> GetAllByCompanyId([FromRoute] GetProjectListByCompanyIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpGet(Router.ProjectRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetProjectByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.ProjectRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddProjectCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPut(Router.ProjectRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateProjectCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpDelete(Router.ProjectRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteProjectCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
