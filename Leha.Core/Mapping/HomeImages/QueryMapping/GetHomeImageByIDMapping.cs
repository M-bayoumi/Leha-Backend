using AutoMapper;
using Leha.Core.Features.HomeImages.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.HomeImages;

public partial class HomeImageProfile : Profile
{
    public void GetHomeImageByIdMapping()
    {
        CreateMap<HomeImage, GetHomeImageByIdResponse>()
             .ForMember(dist => dist.CompanyName, opt => opt.MapFrom(src => src.Company.GetLocalized(src.Company.NameAr, src.Company.NameEn)))
             .ForMember(dist => dist.CompanySlogan, opt => opt.MapFrom(src => src.Company.GetLocalized(src.Company.SloganAr, src.Company.SloganEn)))
             .ForMember(dist => dist.CompanyEmployees, opt => opt.MapFrom(src => src.Company.Employees))
             .ForMember(dist => dist.CompanyImage, opt => opt.MapFrom(src => src.Company.Image))
             .ForMember(dist => dist.CompanyEmail, opt => opt.MapFrom(src => src.Company.Email))
             .ForMember(dist => dist.CompanyPhone, opt => opt.MapFrom(src => src.Company.Phone))
             .ForMember(dist => dist.CompanyLink, opt => opt.MapFrom(src => src.Company.Link));
    }
}
