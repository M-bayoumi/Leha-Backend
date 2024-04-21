using AutoMapper;
using Leha.Core.Features.PhaseItems.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.PhaseItems;
public partial class PhaseItemProfile : Profile
{
    public void GetPhaseItemDetailsMapping()
    {
        CreateMap<PhaseItem, GetPhaseItemDetailsResponse>();
    }
}
