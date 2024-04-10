
using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class HomeImage : LocalizableEntity
{
    public int Id { get; set; }
    public string ImageBytes { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public HomeImage()
    {
    }

    public HomeImage(int id, string imageBytes, int companyId)
    {
        Id = id;
        ImageBytes = imageBytes;
        CompanyId = companyId;
    }
}
