using AutoMapper;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.ProjectPhases;
public partial class ProjectPhaseProfile : Profile
{
    public void GetProjectPhaseDetailsMapping()
    {
        CreateMap<ProjectPhase, GetProjectPhaseDetailsResponse>();

    }
}
