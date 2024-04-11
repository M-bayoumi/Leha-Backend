using AutoMapper;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.ProjectPhases;
public partial class ProjectPhaseProfile : Profile
{
    public void GetProjectPhaseListByCompanyIDMapping()
    {
        CreateMap<ProjectPhase, GetProjectPhaseListByProjectIDResponse>()
             .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)))
             .ForMember(dist => dist.ProjectName, opt => opt.MapFrom(src => src.Project.GetLocalized(src.Project.NameAr, src.Project.NameEn)))
             .ForMember(dist => dist.ProjectDescription, opt => opt.MapFrom(src => src.Project.GetLocalized(src.Project.DescriptionAr, src.Project.DescriptionEn)))
             .ForMember(dist => dist.ProjectAddress, opt => opt.MapFrom(src => src.Project.GetLocalized(src.Project.AddressAr, src.Project.AddressEn)))
             .ForMember(dist => dist.ProjectImage, opt => opt.MapFrom(src => src.Project.Image))
             .ForMember(dist => dist.ProjectSiteEngineerName, opt => opt.MapFrom(src => src.Project.GetLocalized(src.Project.SiteEngineerNameAr, src.Project.SiteEngineerNameEn)))
             .ForMember(dist => dist.ProjectProgressPercentage, opt => opt.MapFrom(src => src.Project.ProjectProgressPercentage));
    }
}
