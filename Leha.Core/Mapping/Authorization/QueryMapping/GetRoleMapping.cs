using AutoMapper;
using Leha.Core.Features.Authorization.Quaries.Results;
using Microsoft.AspNetCore.Identity;

namespace Leha.Core.Mapping.Authorization;

public partial class RoleProfile : Profile
{
    public void GetRoleMapping()
    {
        CreateMap<IdentityRole, GetRoleListResponse>();
    }
}
