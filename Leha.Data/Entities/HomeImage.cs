
using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class HomeImage : LocalizableEntity
{
    public int Id { get; set; }
    public string ImageURL { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public HomeImage()
    {
    }

    public HomeImage(int id, string imageURL, int companyId)
    {
        Id = id;
        ImageURL = imageURL;
        CompanyId = companyId;
    }
}
