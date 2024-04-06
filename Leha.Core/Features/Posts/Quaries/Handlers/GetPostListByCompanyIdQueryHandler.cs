using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Posts.Quaries.Models;
using Leha.Core.Features.Posts.Quaries.Results;
using Leha.Manager.Managers.Posts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.Posts.Quaries.Handlers;

public class GetPostListByCompanyIdQueryHandler : ResponseHandler, IRequestHandler<GetPostListByCompanyIdQuery, Response<List<GetPostListByCompanyIDResponse>>>
{
    #region Fields
    private readonly IPostManager _postManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetPostListByCompanyIdQueryHandler(IPostManager postManager, IMapper mapper)
    {
        _postManager = postManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetPostListByCompanyIDResponse>>> Handle(GetPostListByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var postListDB = await _postManager.GetPostsListByCompanyId(request.ID).Include(x => x.Company).ToListAsync();
        if (postListDB is null)
        {
            return NotFound<List<GetPostListByCompanyIDResponse>>();
        }
        var postListMapper = _mapper.Map<List<GetPostListByCompanyIDResponse>>(postListDB);
        return Success(postListMapper);
    }
    #endregion

}
