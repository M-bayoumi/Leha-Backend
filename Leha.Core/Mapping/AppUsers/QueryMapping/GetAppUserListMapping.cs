using AutoMapper;
using Leha.Core.Features.AppUsers.Quaries.Results;
using Leha.Data.Entities.Identity;

namespace Leha.Core.Mapping.AppUsers;

public partial class AppUserProfile : Profile
{
    public void GetAppUserListMapping()
    {
        CreateMap<AppUser, GetAppUserListResponse>();
    }
}
