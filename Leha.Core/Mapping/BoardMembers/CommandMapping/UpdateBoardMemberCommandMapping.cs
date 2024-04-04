using AutoMapper;
using Leha.Core.Features.BoardMembers.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.BoardMembers;

public partial class BoardMemberProfile : Profile
{
    public void UpdateBoardMemberCommandMapping()
    {
        CreateMap<UpdateBoardMemberCommand, BoardMember>();
        //.ForMember(dest => dest.ID, opt => opt.Ignore()); // that is no neet to map id;
    }
}
