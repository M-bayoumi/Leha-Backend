using AutoMapper;
using Leha.Core.Features.AppUsers.Commands.Models;
using Leha.Data.Entities.Identity;

namespace Leha.Core.Mapping.AppUsers;

public partial class AppUserProfile : Profile
{
    public void UpdateAppUserCommandMapping()
    {
        CreateMap<UpdateAppUserCommand, AppUser>();
    }
}
