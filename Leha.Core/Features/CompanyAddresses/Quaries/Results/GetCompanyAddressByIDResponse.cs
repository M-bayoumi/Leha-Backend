namespace Leha.Core.Features.CompanyAddresses.Quaries.Results;

public class GetCompanyAddressByIdResponse
{
    public int Id { get; set; }
    public string Address { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string CompanyPhone { get; set; } = string.Empty;
    public string CompanyLink { get; set; } = string.Empty;
}
