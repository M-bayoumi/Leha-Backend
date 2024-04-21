using AutoMapper;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.BoardMemberSpeeches;

public partial class BoardMemberSpeechProfile : Profile
{

    public void GetBoardMemberSpeechDetailsMapping()
    {
        CreateMap<BoardMemberSpeech, GetBoardMemberSpeechDetailsResponse>();
    }
}
