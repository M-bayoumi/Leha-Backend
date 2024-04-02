
namespace Leha.Data.Entities;

public class BoardMember
{
    public int ID { get; set; }
    public string BoardMemberName { get; set; } = string.Empty;
    public string BoardMemberImage { get; set; } = string.Empty;
    public string BoardMemberPosition { get; set; } = string.Empty;

    public List<BoardMemberSpeech> BoardMemberSpeeches { get; set; } = new List<BoardMemberSpeech>();


    public BoardMember()
    {
    }

    public BoardMember(int iD, string boardMemberName, string boardMemberImage, string boardMemberPosition)
    {
        ID = iD;
        BoardMemberName = boardMemberName;
        BoardMemberImage = boardMemberImage;
        BoardMemberPosition = boardMemberPosition;
    }
}
