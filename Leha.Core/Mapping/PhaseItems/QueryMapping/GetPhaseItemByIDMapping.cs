using AutoMapper;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.PhaseItems;

public partial class PhaseItemProfile : Profile
{
    public void GetPhaseItemByIdMapping()
    {
        CreateMap<PhaseItem, GetPhaseItemByIdResponse>()
             .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)))
             .ForMember(dist => dist.ExecutionProgress, opt => opt.MapFrom(src => src.GetLocalized(src.ExecutionProgressAr, src.ExecutionProgressEn)))
             .ForMember(dist => dist.RFI, opt => opt.MapFrom(src => src.GetLocalized(src.RFIAr, src.RFIEn)))
             .ForMember(dist => dist.WIR, opt => opt.MapFrom(src => src.GetLocalized(src.WIRAr, src.WIREn)))
             .ForMember(dist => dist.Schedule, opt => opt.MapFrom(src => src.GetLocalized(src.ScheduleAr, src.ScheduleEn)))
             .ForMember(dist => dist.Unit, opt => opt.MapFrom(src => src.GetLocalized(src.UnitAr, src.UnitEn)))
             .ForMember(dist => dist.ProjectPhaseName, opt => opt.MapFrom(src => src.ProjectPhase.GetLocalized(src.ProjectPhase.NameAr, src.ProjectPhase.NameEn)));
    }
}
