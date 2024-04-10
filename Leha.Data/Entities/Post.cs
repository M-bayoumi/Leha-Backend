using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class Post : LocalizableEntity
{
    public int Id { get; set; }
    public string ContentAr { get; set; } = string.Empty;
    public string ContentEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public Post()
    {
    }

    public Post(int id, string contentAr, string contentEn, string image, int companyId)
    {
        Id = id;
        ContentAr = contentAr;
        ContentEn = contentEn;
        Image = image;
        CompanyId = companyId;
    }
}

