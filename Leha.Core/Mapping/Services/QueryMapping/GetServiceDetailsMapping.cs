using AutoMapper;
using Leha.Core.Features.Services.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Services;
public partial class ServiceProfile : Profile
{
    public void GetServiceDetailsMapping()
    {
        CreateMap<Service, GetServiceDetailsResponse>();
    }
}
