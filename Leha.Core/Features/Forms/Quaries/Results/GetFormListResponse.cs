namespace Leha.Core.Features.Forms.Quaries.Results;

public class GetFormListResponse
{
    public int Id { get; set; }
    public string FullNameAr { get; set; } = string.Empty;
    public string FullNameEn { get; set; } = string.Empty;
    public string AddressAr { get; set; } = string.Empty;
    public string AddressEn { get; set; } = string.Empty;
    public string JobTitleAr { get; set; } = string.Empty;
    public string JobTitleEn { get; set; } = string.Empty;
    public string CV { get; set; } = string.Empty;
    public int JobId { get; set; }
    public DateTime FormDateTime { get; set; } = DateTime.Now;
    public string TitleAr { get; set; } = string.Empty;
    public string TitleEn { get; set; } = string.Empty;
    public string DescriptionAr { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public string AverageSalary { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public DateTime JobDateTime { get; set; } = DateTime.Now;
}
