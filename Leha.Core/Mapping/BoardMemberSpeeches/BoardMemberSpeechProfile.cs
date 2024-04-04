namespace Leha.Core.Mapping.BoardMemberSpeeches
{
    public partial class BoardMemberSpeechProfile
    {
        public BoardMemberSpeechProfile()
        {
            GetBoardMemberSpeechByIDMapping();
            GetBoardMemberSpeechListMapping();
            AddBoardMemberSpeechCommandMapping();
            UpdateBoardMemberSpeechCommandMapping();
        }
    }
}
