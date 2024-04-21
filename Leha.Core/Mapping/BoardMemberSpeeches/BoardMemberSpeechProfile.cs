namespace Leha.Core.Mapping.BoardMemberSpeeches
{
    public partial class BoardMemberSpeechProfile
    {
        public BoardMemberSpeechProfile()
        {
            GetBoardMemberSpeechListMapping();
            GetBoardMemberSpeechByIdMapping();
            GetBoardMemberSpeechDetailsMapping();
            GetBoardMemberSpeechListByBoardMemberIDMapping();
            AddBoardMemberSpeechCommandMapping();
            UpdateBoardMemberSpeechCommandMapping();
        }
    }
}
