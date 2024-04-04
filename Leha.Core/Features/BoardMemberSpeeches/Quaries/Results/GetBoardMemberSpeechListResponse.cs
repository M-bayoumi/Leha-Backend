namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;

public class GetBoardMemberSpeechListResponse
{
    public int ID { get; set; }
    public string BoardMemberSpeechContent { get; set; } = string.Empty;
    public int BoardMemberID { get; set; }
    public string BoardMemberName { get; set; } = string.Empty;
    public string BoardMemberImage { get; set; } = string.Empty;
    public string BoardMemberPosition { get; set; } = string.Empty;
}
