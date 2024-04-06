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

    [HttpGet(Router.ProjectPhaseRouting.GetList)]

    public async Task<IActionResult> GetProjectPhaseList()
    {
        var response = await _mediator.Send(new GetProjectPhaseListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ProjectPhaseRouting.GetListByProjectID)]

    public async Task<IActionResult> GetProjectPhaseListByCompanyID([FromRoute] GetProjectPhaseListByProjectIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.ProjectPhaseRouting.GetByID)]
    public async Task<IActionResult> GetProjectPhaseByID([FromRoute] GetProjectPhaseByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.ProjectPhaseRouting.Add)]
    public async Task<IActionResult> AddProjectPhase([FromBody] AddProjectPhaseCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.ProjectPhaseRouting.Update)]
    public async Task<IActionResult> UpdateProjectPhase([FromBody] UpdateProjectPhaseCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.ProjectPhaseRouting.Delete)]
    public async Task<IActionResult> DeleteProjectPhase([FromRoute] DeleteProjectPhaseCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
