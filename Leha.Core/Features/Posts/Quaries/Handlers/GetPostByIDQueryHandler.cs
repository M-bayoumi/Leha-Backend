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


public class GetPostByIDQueryHandler : ResponseHandler, IRequestHandler<GetPostByIDQuery, Response<GetPostByIDResponse>>
{
    #region Fields
    private readonly IPostManager _postManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetPostByIDQueryHandler(IPostManager postManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _postManager = postManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetPostByIDResponse>> Handle(GetPostByIDQuery request, CancellationToken cancellationToken)
    {
        var postDB = await _postManager.GetPostsListAsync().Include(x => x.Company).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (postDB is null)
        {
            return NotFound<GetPostByIDResponse>();
        }
        var postMapper = _mapper.Map<GetPostByIDResponse>(postDB);
        return Success(postMapper);
    }
    #endregion

}
