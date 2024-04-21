namespace Leha.Core.Features.Projects.Quaries.Results;

public class GetProjectDetailsResponse
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string DescriptionAr { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public string AddressAr { get; set; } = string.Empty;
    public string AddressEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string SiteEngineerNameAr { get; set; } = string.Empty;
    public string SiteEngineerNameEn { get; set; } = string.Empty;
    public decimal ProjectProgressPercentage { get; set; }
    public int CompanyId { get; set; }
}
