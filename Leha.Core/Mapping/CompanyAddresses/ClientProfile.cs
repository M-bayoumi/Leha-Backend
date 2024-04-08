namespace Leha.Core.Mapping.CompanyAddresses;


public partial class CompanyAddressProfile
{
    public CompanyAddressProfile()
    {
        GetCompanyAddressByIdMapping();
        GetCompanyAddressListMapping();
        GetCompanyAddressListByCompanyIDMapping();
        AddCompanyAddressCommandMapping();
        UpdateCompanyAddressCommandMapping();
    }
}
