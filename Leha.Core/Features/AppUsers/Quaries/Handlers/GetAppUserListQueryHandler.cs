using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.AppUsers.Quaries.Models;
using Leha.Core.Features.AppUsers.Quaries.Results;
using Leha.Core.Resources;
using Leha.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.AppUsers.Quaries.Handlers;

public class GetAppUserListQueryHandler : ResponseHandler, IRequestHandler<GetAppUserListQuery, Response<GetAppUserListResponse>>
{
    #region Fields
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetAppUserListQueryHandler(UserManager<AppUser> userManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetAppUserListResponse>> Handle(GetAppUserListQuery request, CancellationToken cancellationToken)
    {
        //var userDb = await _userManager.FindByIdAsync(request.Id);
        var userDb = await _userManager.Users.ToListAsync();
        if (userDb is null)
        {
            return NotFound<GetAppUserListResponse>();
        }
        var usersMapper = _mapper.Map<GetAppUserListResponse>(userDb);
        return Success(usersMapper);
    }
    #endregion

}