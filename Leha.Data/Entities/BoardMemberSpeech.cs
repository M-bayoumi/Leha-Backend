
using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class BoardMemberSpeech : LocalizableEntity
{
    public int Id { get; set; }
    public string ContentAr { get; set; } = string.Empty;
    public string ContentEn { get; set; } = string.Empty;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public int BoardMemberId { get; set; }
    public BoardMember BoardMember { get; set; } = null!;

    public BoardMemberSpeech()
    {
    }

    public BoardMemberSpeech(int id, string contentAr, string contentEn, int boardMemberId)
    {
        Id = id;
        ContentAr = contentAr;
        ContentEn = contentEn;
        BoardMemberId = boardMemberId;
    }
}
