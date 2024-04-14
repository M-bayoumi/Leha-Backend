using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.AppUsers.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.AppUsers.Commands.Handlers;

public class ChangeAppUserPasswordCommandHandler : ResponseHandler, IRequestHandler<ChangeAppUserPasswordCommand, Response<string>>
{

    #region Fields
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    #endregion

    #region Constructors
    public ChangeAppUserPasswordCommandHandler(IMapper mapper, IStringLocalizer<SharedResources> localizer, UserManager<AppUser> userManager) : base(localizer)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(ChangeAppUserPasswordCommand request, CancellationToken cancellationToken)
    {
        var dm = await _userManager.FindByIdAsync(request.Id);
        if (dm == null) return NotFound<string>();

        var result = await _userManager.ChangePasswordAsync(dm, request.CurrentPassword, request.NewPassword);
        if (result.Succeeded)
            return Created("");

        return BadRequest<string>(result.Errors.FirstOrDefault().Description);
    }

    #endregion
}
