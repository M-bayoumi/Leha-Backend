using AutoMapper;
using Leha.Core.Features.Projects.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Projects;
public partial class ProjectProfile : Profile
{
    public void GetProjectDetailsMapping()
    {
        CreateMap<Project, GetProjectDetailsResponse>();
    }
}
