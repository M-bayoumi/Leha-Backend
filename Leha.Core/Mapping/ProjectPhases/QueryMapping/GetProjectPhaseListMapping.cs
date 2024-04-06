using AutoMapper;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.ProjectPhases;
public partial class ProjectPhaseProfile : Profile
{
    public void GetProjectPhaseListMapping()
    {
        CreateMap<ProjectPhase, GetProjectPhaseListResponse>()
             .ForMember(dist => dist.ProjectName, opt => opt.MapFrom(src => src.Project.ProjectName))
             .ForMember(dist => dist.ProjectDescription, opt => opt.MapFrom(src => src.Project.ProjectDescription))
             .ForMember(dist => dist.ProjectAddress, opt => opt.MapFrom(src => src.Project.ProjectAddress))
             .ForMember(dist => dist.ProjectImage, opt => opt.MapFrom(src => src.Project.ProjectImage))
             .ForMember(dist => dist.SiteEngineerName, opt => opt.MapFrom(src => src.Project.SiteEngineerName))
             .ForMember(dist => dist.ProjectProgressPercentage, opt => opt.MapFrom(src => src.Project.ProjectProgressPercentage));
    }
}
