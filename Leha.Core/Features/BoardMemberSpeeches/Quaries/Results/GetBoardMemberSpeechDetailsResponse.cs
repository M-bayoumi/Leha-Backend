namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;

public class GetBoardMemberSpeechDetailsResponse
{
    public int Id { get; set; }
    public string ContentAr { get; set; } = string.Empty;
    public string ContentEn { get; set; } = string.Empty;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public int BoardMemberId { get; set; }
}
