using AutoMapper;
using Leha.Core.Features.CompanyAddresses.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.CompanyAddresses;
public partial class CompanyAddressProfile : Profile
{
    public void GetCompanyAddressDetailsMapping()
    {
        CreateMap<CompanyAddress, GetCompanyAddressDetailsResponse>();
    }
}
