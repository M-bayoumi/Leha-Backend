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

public class GetPostListByCompanyIDQueryHandler : ResponseHandler, IRequestHandler<GetPostListByCompanyIDQuery, Response<List<GetPostListByCompanyIDResponse>>>
{
    #region Fields
    private readonly IPostManager _postManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetPostListByCompanyIDQueryHandler(IPostManager postManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _postManager = postManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetPostListByCompanyIDResponse>>> Handle(GetPostListByCompanyIDQuery request, CancellationToken cancellationToken)
    {
        var postListDB = await _postManager.GetAllByCompanyId(request.Id).Include(x => x.Company).ToListAsync();
        if (postListDB is null)
        {
            return NotFound<List<GetPostListByCompanyIDResponse>>();
        }
        var postListMapper = _mapper.Map<List<GetPostListByCompanyIDResponse>>(postListDB);
        return Success(postListMapper);
    }
    #endregion

}
