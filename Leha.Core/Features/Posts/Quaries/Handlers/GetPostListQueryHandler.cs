using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Quaries.Models;
using Leha.Core.Features.Posts.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Posts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Posts.Quaries.Handlers;

public class GetPostListQueryHandler : ResponseHandler, IRequestHandler<GetPostListQuery, Response<List<GetPostListResponse>>>
{
    #region Fields
    private readonly IPostManager _postManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetPostListQueryHandler(IPostManager postManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _postManager = postManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetPostListResponse>>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
    {
        var postListDB = await _postManager.GetPostsListAsync().Include(x => x.Company).ToListAsync();
        if (postListDB is null)
        {
            return NotFound<List<GetPostListResponse>>();
        }
        var postListMapper = _mapper.Map<List<GetPostListResponse>>(postListDB);
        return Success(postListMapper);
    }
    #endregion

}