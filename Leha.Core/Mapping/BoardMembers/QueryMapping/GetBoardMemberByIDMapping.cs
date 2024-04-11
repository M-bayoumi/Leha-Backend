using AutoMapper;
using Leha.Core.Features.BoardMembers.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.BoardMembers;

public partial class BoardMemberProfile : Profile
{
    public void GetBoardMemberByIdMapping()
    {
        CreateMap<BoardMember, GetBoardMemberByIdResponse>()
             .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)))
             .ForMember(dist => dist.Position, opt => opt.MapFrom(src => src.GetLocalized(src.PositionAr, src.PositionEn)));
    }
}
