using AutoMapper;
using Leha.Core.Features.Forms.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Forms;

public partial class FormProfile : Profile
{
    public void GetFormByIdMapping()
    {
        CreateMap<Form, GetFormByIdResponse>()
             .ForMember(dist => dist.JobTitle, opt => opt.MapFrom(src => src.Job.JobTitle))
             .ForMember(dist => dist.JobDescription, opt => opt.MapFrom(src => src.Job.JobDescription))
             .ForMember(dist => dist.JobAverageSalary, opt => opt.MapFrom(src => src.Job.JobAverageSalary))
             .ForMember(dist => dist.JobDateTime, opt => opt.MapFrom(src => src.Job.JobDateTime));
    }
}
