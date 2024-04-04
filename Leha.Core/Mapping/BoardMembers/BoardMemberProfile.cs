namespace Leha.Core.Mapping.BoardMembers
{
    public partial class BoardMemberProfile
    {
        public BoardMemberProfile()
        {
            GetBoardMemberByIDMapping();
            GetBoardMemberListMapping();
            AddBoardMemberCommandMapping();
            UpdateBoardMemberCommandMapping();
        }
    }
}
