using Leha.Api.BaseController;
using Leha.Core.Features.CompanyAddresses.Commands.Models;
using Leha.Core.Features.CompanyAddresses.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class CompanyAddressController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.CompanyAddressRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetCompanyAddressListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.CompanyAddressRouting.GetAllByCompanyId)]

    public async Task<IActionResult> GetAllByCompanyId([FromRoute] GetCompanyAddressListByCompanyIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.CompanyAddressRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetCompanyAddressByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpGet(Router.CompanyAddressRouting.GetDetails)]
    public async Task<IActionResult> GetDetails([FromRoute] GetCompanyAddressDetailsQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);

    }
    [HttpPost(Router.CompanyAddressRouting.Add)]
    public async Task<IActionResult> Add([FromForm] AddCompanyAddressCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.CompanyAddressRouting.Update)]
    public async Task<IActionResult> Update([FromForm] UpdateCompanyAddressCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.CompanyAddressRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteCompanyAddressCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
