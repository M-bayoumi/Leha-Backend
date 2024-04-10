namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;

public class GetBoardMemberSpeechByIdResponse
{
    public int Id { get; set; }
    public string ContentAr { get; set; } = string.Empty;
    public string ContentEn { get; set; } = string.Empty;
    public int BoardMemberId { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string PositionAr { get; set; } = string.Empty;
    public string PositionEn { get; set; } = string.Empty;
}
