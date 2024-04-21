namespace Leha.Core.Features.CompanyAddresses.Quaries.Results;

public class GetCompanyAddressDetailsResponse
{
    public int Id { get; set; }
    public string AddressAr { get; set; } = string.Empty;
    public string AddressEn { get; set; } = string.Empty;
    public int CompanyId { get; set; }
}
