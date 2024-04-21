using Leha.Api.BaseController;
using Leha.Core.Features.HomeImages.Commands.Models;
using Leha.Core.Features.HomeImages.Quaries.Models;
using Leha.Data.AppMetaData;
using Leha.Data.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class HomeImageController : AppControllerBase
{
    #region Fields
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly JwtSettings _jwtSettings;
    #endregion

    #region Constructors
    public HomeImageController(IWebHostEnvironment webHostEnvironment, JwtSettings jwtSettings)
    {
        _webHostEnvironment = webHostEnvironment;
        _jwtSettings = jwtSettings;

    }
    #endregion


    #region Handle Functions

    [HttpGet(Router.HomeImageRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetHomeImageListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.HomeImageRouting.GetAllByCompanyId)]

    public async Task<IActionResult> GetAllByCompanyId([FromRoute] GetHomeImageListByCompanyIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.HomeImageRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetHomeImageByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.HomeImageRouting.Add)]
    public async Task<IActionResult> Add([FromForm] IFormFile file, [FromForm] AddHomeImageCommand command)
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

        command.ImageURL = imageUrl;

        var response = await _mediator.Send(command);

        return NewResult(response);

    }

    [HttpPut(Router.HomeImageRouting.Update)]
    public async Task<IActionResult> UpdateAsync([FromForm] IFormFile file, [FromForm] UpdateHomeImageCommand command)
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


        command.ImageURL = newImageUrl;
        var response = await _mediator.Send(command);
        return NewResult(response);

    }

    [HttpDelete(Router.HomeImageRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteHomeImageCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
