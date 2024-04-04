using AutoMapper;
using Leha.Core.Features.BoardMemberSpeeches.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.BoardMemberSpeeches;

public partial class BoardMemberSpeechProfile : Profile
{
    public void AddBoardMemberSpeechCommandMapping()
    {
        CreateMap<AddBoardMemberSpeechCommand, BoardMemberSpeech>();
    }
}
