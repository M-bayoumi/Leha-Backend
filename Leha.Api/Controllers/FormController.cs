using Leha.Api.BaseController;
using Leha.Core.Features.Forms.Commands.Models;
using Leha.Core.Features.Forms.Quaries.Models;
using Leha.Data.AppMetaData;
using Leha.Data.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class FormController : AppControllerBase
{
    #region Fields
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly JwtSettings _jwtSettings;
    #endregion

    #region Constructors
    public FormController(IWebHostEnvironment webHostEnvironment, JwtSettings jwtSettings)
    {
        _webHostEnvironment = webHostEnvironment;
        _jwtSettings = jwtSettings;

    }
    #endregion

    #region Handle Functions

    [HttpGet(Router.FormRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetFormListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.FormRouting.GetAllByJobId)]

    public async Task<IActionResult> GetAllByJobId([FromRoute] GetFormListByJobIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpGet(Router.FormRouting.GetDetails)]
    public async Task<IActionResult> GetDetails([FromRoute] GetFormDetailsQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpGet(Router.FormRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetFormByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }


    [HttpPost(Router.FormRouting.Add)]
    public async Task<IActionResult> Add([FromForm] IFormFile file, [FromForm] AddFormCommand command)
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

        command.CV = imageUrl;

        var response = await _mediator.Send(command);

        return NewResult(response);

    }

    [HttpPut(Router.FormRouting.Update)]
    public async Task<IActionResult> UpdateAsync([FromForm] IFormFile file, [FromForm] UpdateFormCommand command)
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


        command.CV = newImageUrl;
        var response = await _mediator.Send(command);
        return NewResult(response);

    }
    [HttpDelete(Router.FormRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteFormCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
