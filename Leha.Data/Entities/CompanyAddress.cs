
using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class CompanyAddress : LocalizableEntity
{

    public int Id { get; set; }
    public string AddressAr { get; set; } = string.Empty;
    public string AddressEn { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

    public CompanyAddress()
    {
    }

    public CompanyAddress(int id, string addressAr, string addressEn, int companyId)
    {
        Id = id;
        AddressAr = addressAr;
        AddressEn = addressEn;
        CompanyId = companyId;
    }
}
