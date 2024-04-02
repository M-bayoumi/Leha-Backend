
namespace Leha.Data.Entities;

public class BoardMemberSpeech
{
    public int ID { get; set; }
    public string BoardMemberSpeechContent { get; set; } = string.Empty;
    public int BoardMemberID { get; set; }
    public BoardMember BoardMember { get; set; } = null!;
    public BoardMemberSpeech()
    {
    }

    public BoardMemberSpeech(int iD, string boardMemberSpeechContent, int boardMemberID)
    {
        ID = iD;
        BoardMemberSpeechContent = boardMemberSpeechContent;
        BoardMemberID = boardMemberID;
    }
}
