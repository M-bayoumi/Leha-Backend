using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Commands.Models;
using Leha.Manager.Managers.Posts;
using MediatR;

namespace Leha.Core.Features.Posts.Commands.Handlers;

public class DeletePostCommandHandler : ResponseHandler, IRequestHandler<DeletePostCommand, Response<string>>
{

    #region Fields
    private readonly IPostManager _postManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeletePostCommandHandler(IPostManager postManager, IMapper mapper)
    {
        _postManager = postManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postManager.GetPostByIDAsync(request.ID);
        if (post == null) return NotFound<string>("Post not found");
        return await _postManager.DeletePostAsync(post) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}