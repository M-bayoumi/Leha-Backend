using AutoMapper;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.PhaseItems;
public partial class PhaseItemProfile : Profile
{
    public void GetPhaseItemListByProjectPhaseIDMapping()
    {
        CreateMap<PhaseItem, GetPhaseItemListByProjectPhaseIDResponse>()
            .ForMember(dist => dist.ProjectPhaseName, opt => opt.MapFrom(src => src.ProjectPhase.ProjectPhaseName));

    }
}
