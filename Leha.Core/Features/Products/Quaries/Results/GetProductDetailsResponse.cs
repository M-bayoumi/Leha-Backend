namespace Leha.Core.Features.Products.Quaries.Results;

public class GetProductDetailsResponse
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string DescriptionAr { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CompanyId { get; set; }
}
