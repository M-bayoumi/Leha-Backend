namespace Leha.Core.Features.Clients.Quaries.Results;

public class GetClientDetailsResponse
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CompanyId { get; set; }
}
