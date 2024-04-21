using AutoMapper;
using Leha.Core.Features.Jobs.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Jobs;
public partial class JobProfile : Profile
{
    public void GetJobDetailsMapping()
    {
        CreateMap<Job, GetJobDetailsResponse>();
    }
}
