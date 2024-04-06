using AutoMapper;
using Leha.Core.Features.Jobs.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Jobs;


public partial class JobProfile : Profile
{
    public void UpdateJobCommandMapping()
    {
        CreateMap<UpdateJobCommand, Job>();
    }
}