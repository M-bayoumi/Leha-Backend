namespace Leha.Core.Mapping.CompanyAddresses;


public partial class CompanyAddressProfile
{
    public CompanyAddressProfile()
    {
        GetCompanyAddressByIDMapping();
        GetCompanyAddressListMapping();
        GetCompanyAddressListByCompanyIDMapping();
        AddCompanyAddressCommandMapping();
        UpdateCompanyAddressCommandMapping();
    }
}
