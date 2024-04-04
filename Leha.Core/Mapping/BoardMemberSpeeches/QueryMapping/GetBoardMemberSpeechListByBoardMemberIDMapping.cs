using AutoMapper;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.BoardMemberSpeeches;

public partial class BoardMemberSpeechProfile : Profile
{
    public void GetBoardMemberSpeechListByBoardMemberIDMapping()
    {
        CreateMap<BoardMemberSpeech, GetBoardMemberSpeechListByBoardMemberIDResponse>()
             .ForMember(dist => dist.BoardMemberName, opt => opt.MapFrom(src => src.BoardMember.BoardMemberName))
             .ForMember(dist => dist.BoardMemberPosition, opt => opt.MapFrom(src => src.BoardMember.BoardMemberPosition))
             .ForMember(dist => dist.BoardMemberPosition, opt => opt.MapFrom(src => src.BoardMember.BoardMemberPosition));
    }
}
