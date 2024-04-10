using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class Client : LocalizableEntity
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public Client()
    {
    }

    public Client(int id, string nameAr, string nameEn, string image, int companyId)
    {
        Id = id;
        NameAr = nameAr;
        NameEn = nameEn;
        Image = image;
        CompanyId = companyId;
    }
}

