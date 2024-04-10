
using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class Product : LocalizableEntity
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string DescriptionAr { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public Product()
    {
    }

    public Product(int id, string nameAr, string nameEn, string descriptionAr, string descriptionEn, string image, int companyId)
    {
        Id = id;
        NameAr = nameAr;
        NameEn = nameEn;
        DescriptionAr = descriptionAr;
        DescriptionEn = descriptionEn;
        Image = image;
        CompanyId = companyId;
    }
}
