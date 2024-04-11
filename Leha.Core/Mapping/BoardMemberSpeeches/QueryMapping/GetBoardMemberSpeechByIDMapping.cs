using AutoMapper;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.BoardMemberSpeeches;

public partial class BoardMemberSpeechProfile : Profile
{

    public void GetBoardMemberSpeechByIdMapping()
    {
        CreateMap<BoardMemberSpeech, GetBoardMemberSpeechByIdResponse>()
             .ForMember(dist => dist.Content, opt => opt.MapFrom(src => src.GetLocalized(src.ContentAr, src.ContentEn)))
             .ForMember(dist => dist.BoardMemberName, opt => opt.MapFrom(src => src.GetLocalized(src.BoardMember.NameAr, src.BoardMember.NameEn)))
             .ForMember(dist => dist.BoardMemberImage, opt => opt.MapFrom(src => src.BoardMember.Image))
             .ForMember(dist => dist.BoardMemberPosition, opt => opt.MapFrom(src => src.GetLocalized(src.BoardMember.PositionAr, src.BoardMember.PositionEn)));
    }
}
