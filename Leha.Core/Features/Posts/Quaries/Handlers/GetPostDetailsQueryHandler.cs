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

public class GetPostDetailsQueryHandler : ResponseHandler, IRequestHandler<GetPostDetailsQuery, Response<GetPostDetailsResponse>>
{
    #region Fields
    private readonly IPostManager _postManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetPostDetailsQueryHandler(IPostManager postManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _postManager = postManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetPostDetailsResponse>> Handle(GetPostDetailsQuery request, CancellationToken cancellationToken)
    {
        var postDB = await _postManager.GetAll().Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (postDB is null)
        {
            return NotFound<GetPostDetailsResponse>();
        }
        var postMapper = _mapper.Map<GetPostDetailsResponse>(postDB);
        return Success(postMapper);
    }
    #endregion

}
