using AutoMapper;
using Leha.Core.Features.Projects.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Projects;


public partial class ProjectProfile : Profile
{
    public void AddProjectCommandMapping()
    {
        CreateMap<AddProjectCommand, Project>();
    }
}
