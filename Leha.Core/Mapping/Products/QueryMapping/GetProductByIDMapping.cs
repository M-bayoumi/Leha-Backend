using AutoMapper;
using Leha.Core.Features.Products.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Products;

public partial class ProductProfile : Profile
{
    public void GetProductByIdMapping()
    {
        CreateMap<Product, GetProductByIdResponse>()
             .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)))
             .ForMember(dist => dist.Description, opt => opt.MapFrom(src => src.GetLocalized(src.DescriptionAr, src.DescriptionEn)))
             .ForMember(dist => dist.CompanyName, opt => opt.MapFrom(src => src.Company.GetLocalized(src.Company.NameAr, src.Company.NameEn)))
             .ForMember(dist => dist.CompanySlogan, opt => opt.MapFrom(src => src.Company.GetLocalized(src.Company.SloganAr, src.Company.SloganEn)))
             .ForMember(dist => dist.CompanyEmployees, opt => opt.MapFrom(src => src.Company.Employees))
             .ForMember(dist => dist.CompanyImage, opt => opt.MapFrom(src => src.Company.Image))
             .ForMember(dist => dist.CompanyEmail, opt => opt.MapFrom(src => src.Company.Email))
             .ForMember(dist => dist.CompanyPhone, opt => opt.MapFrom(src => src.Company.Phone))
             .ForMember(dist => dist.CompanyLink, opt => opt.MapFrom(src => src.Company.Link));
    }
}
