using AutoMapper;
using Leha.Core.Features.CompanyAddresses.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.CompanyAddresses;


public partial class CompanyAddressProfile : Profile
{
    public void AddCompanyAddressCommandMapping()
    {
        CreateMap<AddCompanyAddressCommand, CompanyAddress>();
    }
}
