using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.Posts;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Posts.Commands.Handlers;

public class DeletePostCommandHandler : ResponseHandler, IRequestHandler<DeletePostCommand, Response<string>>
{

    #region Fields
    private readonly IPostManager _postManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeletePostCommandHandler(IPostManager postManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _postManager = postManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var post = await _postManager.GetPostByIDAsync(request.ID);
        if (post == null) return NotFound<string>("");
        if (await _postManager.DeletePostAsync(post))
            return Deleted<string>("");
        return BadRequest<string>();
    }

    #endregion
}