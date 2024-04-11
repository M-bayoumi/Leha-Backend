using AutoMapper;
using Leha.Core.Features.Forms.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Forms;
public partial class FormProfile : Profile
{
    public void GetFormListMapping()
    {
        CreateMap<Form, GetFormListResponse>()
             .ForMember(dist => dist.FullName, opt => opt.MapFrom(src => src.GetLocalized(src.FullNameAr, src.FullNameEn)))
             .ForMember(dist => dist.Address, opt => opt.MapFrom(src => src.GetLocalized(src.AddressAr, src.AddressEn)))
             .ForMember(dist => dist.JobTitle, opt => opt.MapFrom(src => src.GetLocalized(src.JobTitleAr, src.JobTitleEn)))
             .ForMember(dist => dist.FormDateTime, opt => opt.MapFrom(src => src.DateTime))
             .ForMember(dist => dist.JobTitle, opt => opt.MapFrom(src => src.Job.GetLocalized(src.Job.TitleAr, src.Job.TitleEn)))
             .ForMember(dist => dist.Description, opt => opt.MapFrom(src => src.Job.GetLocalized(src.Job.DescriptionAr, src.Job.DescriptionEn)))
             .ForMember(dist => dist.AverageSalary, opt => opt.MapFrom(src => src.Job.GetLocalized(src.Job.AverageSalary, src.Job.AverageSalary)))
             .ForMember(dist => dist.JobDateTime, opt => opt.MapFrom(src => src.Job.DateTime));
    }
}
