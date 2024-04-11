using AutoMapper;
using Leha.Core.Features.Jobs.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Jobs;
public partial class JobProfile : Profile
{
    public void GetJobListByCompanyIDMapping()
    {
        CreateMap<Job, GetJobListByCompanyIDResponse>()
             .ForMember(dist => dist.Title, opt => opt.MapFrom(src => src.GetLocalized(src.TitleAr, src.TitleEn)))
             .ForMember(dist => dist.Description, opt => opt.MapFrom(src => src.GetLocalized(src.DescriptionAr, src.DescriptionEn)))
             .ForMember(dist => dist.CompanyName, opt => opt.MapFrom(src => src.Company.GetLocalized(src.Company.NameAr, src.Company.NameEn)))
             .ForMember(dist => dist.CompanyEmployees, opt => opt.MapFrom(src => src.Company.Employees))
             .ForMember(dist => dist.CompanyImage, opt => opt.MapFrom(src => src.Company.Image))
             .ForMember(dist => dist.CompanyEmail, opt => opt.MapFrom(src => src.Company.Email))
             .ForMember(dist => dist.CompanyPhone, opt => opt.MapFrom(src => src.Company.Phone))
             .ForMember(dist => dist.CompanyLink, opt => opt.MapFrom(src => src.Company.Link));
    }
}
