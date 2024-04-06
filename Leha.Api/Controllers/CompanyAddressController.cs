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

    [HttpGet(Router.CompanyAddressRouting.GetList)]

    public async Task<IActionResult> GetCompanyAddressList()
    {
        var response = await _mediator.Send(new GetCompanyAddressListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.CompanyAddressRouting.GetListByCompanyID)]

    public async Task<IActionResult> GetCompanyAddressListByCompanyID([FromRoute] GetCompanyAddressListByCompanyIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.CompanyAddressRouting.GetByID)]
    public async Task<IActionResult> GetCompanyAddressByID([FromRoute] GetCompanyAddressByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.CompanyAddressRouting.Add)]
    public async Task<IActionResult> AddCompanyAddress([FromBody] AddCompanyAddressCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.CompanyAddressRouting.Update)]
    public async Task<IActionResult> UpdateCompanyAddress([FromBody] UpdateCompanyAddressCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.CompanyAddressRouting.Delete)]
    public async Task<IActionResult> DeleteCompanyAddress([FromRoute] DeleteCompanyAddressCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
