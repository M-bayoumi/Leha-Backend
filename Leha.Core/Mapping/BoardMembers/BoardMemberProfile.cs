namespace Leha.Core.Mapping.BoardMembers;

public partial class BoardMemberProfile
{
    public BoardMemberProfile()
    {
        GetBoardMemberByIdMapping();
        GetBoardMemberDetailsMapping();
        GetBoardMemberListMapping();
        AddBoardMemberCommandMapping();
        UpdateBoardMemberCommandMapping();
    }
}
