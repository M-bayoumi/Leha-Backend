using Leha.Api.BaseController;
using Leha.Core.Features.Products.Commands.Models;
using Leha.Core.Features.Products.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class ProductController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.ProductRouting.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetProductListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ProductRouting.GetAllByCompanyId)]

    public async Task<IActionResult> GetAllByCompanyId([FromRoute] GetProductListByCompanyIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.ProductRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetProductByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.ProductRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddProductCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.ProductRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.ProductRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteProductCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
