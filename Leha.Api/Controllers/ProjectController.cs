using Leha.Api.BaseController;
using Leha.Core.Features.Projects.Commands.Models;
using Leha.Core.Features.Projects.Quaries.Models;
using Leha.Data.AppMetaData;
using Leha.Data.Helper;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class ProjectController : AppControllerBase
{
    #region Fields
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly JwtSettings _jwtSettings;
    #endregion

    #region Constructors
    public ProjectController(IWebHostEnvironment webHostEnvironment, JwtSettings jwtSettings)
    {
        _webHostEnvironment = webHostEnvironment;
        _jwtSettings = jwtSettings;

    }
    #endregion


    #region Handle Functions

    [HttpGet(Router.ProjectRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetProjectListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.ProjectRouting.GetAllByCompanyId)]
    public async Task<IActionResult> GetAllByCompanyId([FromRoute] GetProjectListByCompanyIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpGet(Router.ProjectRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetProjectByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpGet(Router.ProjectRouting.GetDetails)]
    public async Task<IActionResult> GetDetails([FromRoute] GetProjectDetailsQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }


    [HttpPost(Router.ProjectRouting.Add)]
    public async Task<IActionResult> Add([FromForm] IFormFile file, [FromForm] AddProjectCommand command)
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

    [HttpPut(Router.ProjectRouting.Update)]
    public async Task<IActionResult> UpdateAsync([FromForm] IFormFile file, [FromForm] UpdateProjectCommand command)
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

    [HttpDelete(Router.ProjectRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeleteProjectCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
