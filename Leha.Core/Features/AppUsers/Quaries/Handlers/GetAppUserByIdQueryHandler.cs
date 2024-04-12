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

public class GetAppUserByIdQueryHandler : ResponseHandler, IRequestHandler<GetAppUserByIdQuery, Response<GetAppUserByIdResponse>>
{
    #region Fields
    private readonly UserManager<AppUser> _userManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetAppUserByIdQueryHandler(UserManager<AppUser> userManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetAppUserByIdResponse>> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
    {
        var userDb = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
        if (userDb is null)
        {
            return NotFound<GetAppUserByIdResponse>();
        }
        var userMapper = _mapper.Map<GetAppUserByIdResponse>(userDb);
        return Success(userMapper);
    }
    #endregion

}