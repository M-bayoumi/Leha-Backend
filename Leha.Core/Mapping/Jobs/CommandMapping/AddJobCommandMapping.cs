using AutoMapper;
using Leha.Core.Features.Jobs.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Jobs;


public partial class JobProfile : Profile
{
    public void AddJobCommandMapping()
    {
        CreateMap<AddJobCommand, Job>();
    }
}
