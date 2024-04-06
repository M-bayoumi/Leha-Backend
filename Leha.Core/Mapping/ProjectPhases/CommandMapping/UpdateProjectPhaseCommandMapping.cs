using AutoMapper;
using Leha.Core.Features.ProjectPhases.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.ProjectPhases;


public partial class ProjectPhaseProfile : Profile
{
    public void UpdateProjectPhaseCommandMapping()
    {
        CreateMap<UpdateProjectPhaseCommand, ProjectPhase>();
    }
}