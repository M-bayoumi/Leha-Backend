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

    [HttpGet(Router.PostRouting.GetList)]

    public async Task<IActionResult> GetPostList()
    {
        var response = await _mediator.Send(new GetPostListQuery());
        return NewResult(response);
    }

    [HttpGet(Router.PostRouting.GetListByCompanyID)]

    public async Task<IActionResult> GetPostListByCompanyID([FromRoute] GetPostListByCompanyIdQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);


    }
    [HttpGet(Router.PostRouting.GetByID)]
    public async Task<IActionResult> GetPostByID([FromRoute] GetPostByIDQuery command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }

    [HttpPost(Router.PostRouting.Add)]
    public async Task<IActionResult> AddPost([FromBody] AddPostCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpPut(Router.PostRouting.Update)]
    public async Task<IActionResult> UpdatePost([FromBody] UpdatePostCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    [HttpDelete(Router.PostRouting.Delete)]
    public async Task<IActionResult> DeletePost([FromRoute] DeletePostCommand command)
    {
        var response = await _mediator.Send(command);
        return NewResult(response);
    }
    #endregion
}
