using AutoMapper;
using Leha.Core.Features.PhaseItems.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.PhaseItems;


public partial class PhaseItemProfile : Profile
{
    public void AddPhaseItemCommandMapping()
    {
        CreateMap<AddPhaseItemCommand, PhaseItem>();
    }
}
