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

    [HttpGet(Router.CompanyRouting.GetList)]

    public async Task<IActionResult> GetCompanyList()
    {
        var response = await _mediator.Send(new GetCompanyListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.CompanyRouting.GetByID)]
    public async Task<IActionResult> GetCompanyByID([FromRoute] GetCompanyByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.CompanyRouting.Add)]
    public async Task<IActionResult> AddCompany([FromBody] AddCompanyCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.CompanyRouting.Update)]
    public async Task<IActionResult> UpdateCompany([FromBody] UpdateCompanyCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.CompanyRouting.Delete)]
    public async Task<IActionResult> DeleteCompany([FromRoute] DeleteCompanyCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
