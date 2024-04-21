using Leha.Api.BaseController;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Core.Features.Companies.Queries.Models;
using Leha.Data.AppMetaData;
using Leha.Data.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class CompanyController : AppControllerBase
{
    #region Fields
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly JwtSettings _jwtSettings;
    #endregion



    #region Constructors

    public CompanyController(IWebHostEnvironment webHostEnvironment, JwtSettings jwtSettings)
    {
        _webHostEnvironment = webHostEnvironment;
        _jwtSettings = jwtSettings;

    }
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

    [HttpGet(Router.CompanyRouting.GetDetails)]
    public async Task<IActionResult> GetDetails([FromRoute] GetCompanyDetailsQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.CompanyRouting.Add)]
    public async Task<IActionResult> Add([FromForm] IFormFile file, [FromForm] AddCompanyCommand command)
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

    [HttpPut(Router.CompanyRouting.Update)]
    public async Task<IActionResult> UpdateAsync([FromForm] IFormFile file, [FromForm] UpdateCompanyCommand command)
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
    [HttpDelete(Router.CompanyRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteCompanyCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
