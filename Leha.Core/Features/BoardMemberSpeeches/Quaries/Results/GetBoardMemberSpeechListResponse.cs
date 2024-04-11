namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;

public class GetBoardMemberSpeechListResponse
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public int BoardMemberId { get; set; }
    public string BoardMemberName { get; set; } = string.Empty;
    public string BoardMemberImage { get; set; } = string.Empty;
    public string BoardMemberPosition { get; set; } = string.Empty;
}
