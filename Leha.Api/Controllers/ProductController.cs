using Leha.Api.BaseController;
using Leha.Core.Features.Products.Commands.Models;
using Leha.Core.Features.Products.Quaries.Models;
using Leha.Data.AppMetaData;
using Leha.Data.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class ProductController : AppControllerBase
{
    #region Fields
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly JwtSettings _jwtSettings;
    #endregion

    #region Constructors
    public ProductController(IWebHostEnvironment webHostEnvironment, JwtSettings jwtSettings)
    {
        _webHostEnvironment = webHostEnvironment;
        _jwtSettings = jwtSettings;

    }
    #endregion


    #region Handle Functions

    [HttpGet(Router.ProductRouting.GetAll)]
    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetProductListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ProductRouting.GetDetails)]
    public async Task<IActionResult> GetDetails([FromRoute] GetProductDetailsQuery command)
    {
        var response = await _mediator.Send(command);
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
    public async Task<IActionResult> Add([FromForm] IFormFile file, [FromForm] AddProductCommand command)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Invalid file");
        }

        string folderPath;

        if (!Directory.Exists(Path.Combine(_webHostEnvironment!.WebRootPath!, "Images")))
        {
            folderPath = Path.Combine(_webHostEnvironment!.WebRootPath!, "Images");
        }
        else
        {
            Directory.CreateDirectory(Path.Combine(_webHostEnvironment!.WebRootPath!, "Images"));
            folderPath = Path.Combine(_webHostEnvironment!.WebRootPath!, "Images");
        }


        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        string filePath = Path.Combine(folderPath, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        var imageUrl = _jwtSettings.Issure + uniqueFileName;

        command.Image = imageUrl;

        var response = await _mediator.Send(command);

        return NewResult(response);

    }

    [HttpPut(Router.ProductRouting.Update)]
    public async Task<IActionResult> UpdateAsync([FromForm] IFormFile file, [FromForm] UpdateProductCommand command)
    {
        if (file == null || file.Length == 0)
        {
            return BadRequest("Invalid file");
        }

        string folderPath;

        if (!Directory.Exists(Path.Combine(_webHostEnvironment!.WebRootPath!, "Images")))
        {
            folderPath = Path.Combine(_webHostEnvironment!.WebRootPath!, "Images");
        }
        else
        {
            Directory.CreateDirectory(Path.Combine(_webHostEnvironment!.WebRootPath!, "Images"));
            folderPath = Path.Combine(_webHostEnvironment!.WebRootPath!, "Images");
        }


        string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
        string filePath = Path.Combine(folderPath, uniqueFileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        var newImageUrl = _jwtSettings.Issure + uniqueFileName;


        command.Image = newImageUrl;
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
