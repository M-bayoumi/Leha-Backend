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

    [HttpGet(Router.ProjectRouting.GetList)]

    public async Task<IActionResult> GetProjectList()
    {
        var response = await _mediator.Send(new GetProjectListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ProjectRouting.GetListByCompanyID)]

    public async Task<IActionResult> GetProjectListByCompanyID([FromRoute] GetProjectListByCompanyIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.ProjectRouting.GetByID)]
    public async Task<IActionResult> GetProjectByID([FromRoute] GetProjectByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.ProjectRouting.Add)]
    public async Task<IActionResult> AddProject([FromBody] AddProjectCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.ProjectRouting.Update)]
    public async Task<IActionResult> UpdateProject([FromBody] UpdateProjectCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.ProjectRouting.Delete)]
    public async Task<IActionResult> DeleteProject([FromRoute] DeleteProjectCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
