using AutoMapper;
using Leha.Core.Features.HomeImages.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.HomeImages;

public partial class HomeImageProfile : Profile
{
    public void GetHomeImageByIDMapping()
    {
        CreateMap<HomeImage, GetHomeImageByIDResponse>()
             .ForMember(dist => dist.CompanyName, opt => opt.MapFrom(src => src.Company.CompanyName))
             .ForMember(dist => dist.CompanyEmployees, opt => opt.MapFrom(src => src.Company.CompanyEmployees))
             .ForMember(dist => dist.CompanyImage, opt => opt.MapFrom(src => src.Company.CompanyImage))
             .ForMember(dist => dist.CompanyEmail, opt => opt.MapFrom(src => src.Company.CompanyEmail))
             .ForMember(dist => dist.CompanyPhone, opt => opt.MapFrom(src => src.Company.CompanyPhone))
             .ForMember(dist => dist.CompanyLink, opt => opt.MapFrom(src => src.Company.CompanyLink));
    }
}
