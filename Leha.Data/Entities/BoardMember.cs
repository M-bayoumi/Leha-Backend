using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class BoardMember : LocalizableEntity
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string PositionAr { get; set; } = string.Empty;
    public string PositionEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public List<BoardMemberSpeech> BoardMemberSpeeches { get; set; } = new List<BoardMemberSpeech>();

    public BoardMember()
    {
    }

    public BoardMember(int id, string nameAr, string nameEn, string positionAr, string positionEn, string image)
    {
        Id = id;
        NameAr = nameAr;
        NameEn = nameEn;
        PositionAr = positionAr;
        PositionEn = positionEn;
        Image = image;
    }
}
