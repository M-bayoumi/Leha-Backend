using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Authorization.Quaries.Models;
using Leha.Core.Features.Authorization.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Authorization;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Authorization.Quaries.Handlers;

public class GetIdentityRoleListQueryHandler : ResponseHandler, IRequestHandler<GetRoleListQuery, Response<List<GetRoleListResponse>>>
{
    #region Fields
    private readonly IAuthorizationManager _authorizationManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetIdentityRoleListQueryHandler(IAuthorizationManager authorizationManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _authorizationManager = authorizationManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetRoleListResponse>>> Handle(GetRoleListQuery request, CancellationToken cancellationToken)
    {
        var roleDb = await _authorizationManager.GetAll();
        if (roleDb is null)
        {
            return NotFound<List<GetRoleListResponse>>();
        }
        var rolesMapper = _mapper.Map<List<GetRoleListResponse>>(roleDb);
        return Success(rolesMapper);
    }
    #endregion

}