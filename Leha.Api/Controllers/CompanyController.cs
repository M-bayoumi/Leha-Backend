using Leha.Api.BaseController;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Core.Features.Companies.Queries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class CompanyController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.CompanyRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetCompanyListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.CompanyRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetCompanyByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.CompanyRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddCompanyCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.CompanyRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateCompanyCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.CompanyRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteCompanyCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
