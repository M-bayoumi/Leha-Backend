using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Authorization.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.Authorization;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Authorization.Commands.Handlers;

public class AddRoleCommandHandler : ResponseHandler, IRequestHandler<AddRoleCommand, Response<string>>
{

    #region Fields
    private readonly IMapper _mapper;
    private readonly IAuthorizationManager _authorizationManager;
    #endregion

    #region Constructors
    public AddRoleCommandHandler(IMapper mapper, IStringLocalizer<SharedResources> localizer, IAuthorizationManager authorizationManager) : base(localizer)
    {
        _mapper = mapper;
        _authorizationManager = authorizationManager;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        var result = await _authorizationManager.AddRoleAsync(request.Name);

        if (result)
            return Created("");
        return BadRequest<string>("");
    }

    #endregion
}
