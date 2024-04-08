namespace Leha.Core.Mapping.BoardMembers
{
    public partial class BoardMemberProfile
    {
        public BoardMemberProfile()
        {
            GetBoardMemberByIdMapping();
            GetBoardMemberListMapping();
            AddBoardMemberCommandMapping();
            UpdateBoardMemberCommandMapping();
        }
    }
}
