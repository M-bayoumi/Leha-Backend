using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.AppUsers.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;

namespace Leha.Core.Features.AppUsers.Commands.Handlers;

public class AddAppUserCommandHandler : ResponseHandler, IRequestHandler<AddAppUserCommand, Response<string>>
{

    #region Fields
    private readonly IMapper _mapper;
    private readonly UserManager<AppUser> _userManager;
    #endregion

    #region Constructors
    public AddAppUserCommandHandler(IMapper mapper, IStringLocalizer<SharedResources> localizer, UserManager<AppUser> userManager) : base(localizer)
    {
        _mapper = mapper;
        _userManager = userManager;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddAppUserCommand request, CancellationToken cancellationToken)
    {
        // check if email is exist

        var dm = await _userManager.FindByEmailAsync(request.Email);
        if (dm != null) return BadRequest<string>("Email is Exist");


        var userMapper = _mapper.Map<AppUser>(request);
        var result = await _userManager.CreateAsync(userMapper, request.Password);
        if (result.Succeeded)
        {
            var users = await _userManager.Users.ToListAsync();
            if (users.Count() == 1)
            {
                await _userManager.AddToRoleAsync(userMapper, "Admin");
                return Created("");
            }
            else
            {
                if (userMapper.Role.IsNullOrEmpty())
                {

                    await _userManager.AddToRoleAsync(userMapper, "User");
                    return Created("");
                }
                else
                {
                    await _userManager.AddToRoleAsync(userMapper, userMapper.Role);
                    return Created("");
                }
            }
        }


        return BadRequest<string>(result.Errors.FirstOrDefault().Description);
    }

    #endregion
}
