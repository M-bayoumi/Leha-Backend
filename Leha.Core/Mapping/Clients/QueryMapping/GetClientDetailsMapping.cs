using AutoMapper;
using Leha.Core.Features.Clients.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Clients;
public partial class ClientProfile : Profile
{
    public void GetClientDetailsMapping()
    {
        CreateMap<Client, GetClientDetailsResponse>();
    }
}
