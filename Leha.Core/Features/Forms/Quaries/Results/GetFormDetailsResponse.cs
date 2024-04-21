namespace Leha.Core.Features.Forms.Quaries.Results;

public class GetFormDetailsResponse
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
}
