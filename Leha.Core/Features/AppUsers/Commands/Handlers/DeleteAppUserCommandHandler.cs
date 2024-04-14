using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.AppUsers.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.AppUsers.Commands.Handlers;

public class DeleteAppUserCommandHandler : ResponseHandler, IRequestHandler<DeleteAppUserCommand, Response<string>>
{

    #region Fields
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    #endregion

    #region Constructors
    public DeleteAppUserCommandHandler(IMapper mapper, IStringLocalizer<SharedResources> localizer, UserManager<AppUser> userManager) : base(localizer)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
    {
        // check if email is exist

        var dm = await _userManager.FindByIdAsync(request.Id);
        if (dm == null) return NotFound<string>();

        var result = await _userManager.DeleteAsync(dm);
        if (result.Succeeded)
            return Deleted<string>();


        return BadRequest<string>(result.Errors.FirstOrDefault().Description);
    }

    #endregion
}
