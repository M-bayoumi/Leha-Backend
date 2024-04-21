using AutoMapper;
using Leha.Core.Features.BoardMembers.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.BoardMembers;
public partial class BoardMemberProfile : Profile
{
    public void GetBoardMemberDetailsMapping()
    {
        CreateMap<BoardMember, GetBoardMemberDetailsResponse>();
    }
}
