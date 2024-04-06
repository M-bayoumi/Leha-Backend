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

    [HttpGet(Router.ProductRouting.GetList)]

    public async Task<IActionResult> GetProductList()
    {
        var response = await _mediator.Send(new GetProductListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ProductRouting.GetListByCompanyID)]

    public async Task<IActionResult> GetProductListByCompanyID([FromRoute] GetProductListByCompanyIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.ProductRouting.GetByID)]
    public async Task<IActionResult> GetProductByID([FromRoute] GetProductByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.ProductRouting.Add)]
    public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.ProductRouting.Update)]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.ProductRouting.Delete)]
    public async Task<IActionResult> DeleteProduct([FromRoute] DeleteProductCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
