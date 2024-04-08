namespace Leha.Core.Mapping.BoardMemberSpeeches
{
    public partial class BoardMemberSpeechProfile
    {
        public BoardMemberSpeechProfile()
        {
            GetBoardMemberSpeechByIdMapping();
            GetBoardMemberSpeechListMapping();
            GetBoardMemberSpeechListByBoardMemberIDMapping();
            AddBoardMemberSpeechCommandMapping();
            UpdateBoardMemberSpeechCommandMapping();
        }
    }
}
