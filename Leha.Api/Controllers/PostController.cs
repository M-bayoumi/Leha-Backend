using Leha.Api.BaseController;
using Leha.Core.Features.Posts.Commands.Models;
using Leha.Core.Features.Posts.Quaries.Models;
using Leha.Data.AppMetaData;
using Microsoft.AspNetCore.Mvc;

namespace Leha.Api.Controllers;

[ApiController]
public class PostController : AppControllerBase
{
    #region Fields
    #endregion

    #region Constructors
    #endregion


    #region Handle Functions

    [HttpGet(Router.PostRouting.GetAll)]

    public async Task<IActionResult> GetAll()
    {
        var response = await _mediator.Send(new GetPostListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.PostRouting.GetAllByCompanyId)]

    public async Task<IActionResult> GetAllByCompanyId([FromRoute] GetPostListByCompanyIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.PostRouting.GetById)]
    public async Task<IActionResult> GetById([FromRoute] GetPostByIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.PostRouting.Add)]
    public async Task<IActionResult> Add([FromBody] AddPostCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.PostRouting.Update)]
    public async Task<IActionResult> Update([FromBody] UpdatePostCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.PostRouting.Delete)]
    public async Task<IActionResult> Delete([FromRoute] DeletePostCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
