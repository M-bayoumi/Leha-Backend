using AutoMapper;
using Leha.Core.Features.BoardMembers.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.BoardMembers;

public partial class BoardMemberProfile : Profile
{
    public void AddBoardMemberCommandMapping()
    {
        CreateMap<AddBoardMemberCommand, BoardMember>();
    }
}
