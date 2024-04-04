namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;

public class GetBoardMemberSpeechByIDResponse
{
    public int ID { get; set; }
    public string BoardMemberSpeechContent { get; set; } = string.Empty;
    public int BoardMemberID { get; set; }
}
