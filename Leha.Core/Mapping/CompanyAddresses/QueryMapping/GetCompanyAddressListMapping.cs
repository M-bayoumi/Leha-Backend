using AutoMapper;
using Leha.Core.Features.CompanyAddresses.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.CompanyAddresses;
public partial class CompanyAddressProfile : Profile
{
    public void GetCompanyAddressListMapping()
    {
        CreateMap<CompanyAddress, GetCompanyAddressListResponse>()
             .ForMember(dist => dist.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
             .ForMember(dist => dist.CompanyEmployees, opt => opt.MapFrom(src => src.Company.CompanyEmployees))
             .ForMember(dist => dist.CompanyImage, opt => opt.MapFrom(src => src.Company.CompanyImage))
             .ForMember(dist => dist.CompanyEmail, opt => opt.MapFrom(src => src.Company.CompanyEmail))
             .ForMember(dist => dist.CompanyPhone, opt => opt.MapFrom(src => src.Company.CompanyPhone))
             .ForMember(dist => dist.CompanyLink, opt => opt.MapFrom(src => src.Company.CompanyLink));
    }
}
