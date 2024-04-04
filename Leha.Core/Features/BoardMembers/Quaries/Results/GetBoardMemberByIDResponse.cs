namespace Leha.Core.Features.BoardMembers.Quaries.Results;

public class GetBoardMemberByIDResponse
{
    public int ID { get; set; }
    public string BoardMemberName { get; set; } = string.Empty;
    public string BoardMemberImage { get; set; } = string.Empty;
    public string BoardMemberPosition { get; set; } = string.Empty;
}
