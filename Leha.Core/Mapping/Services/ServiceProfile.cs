namespace Leha.Core.Mapping.Services;


public partial class ServiceProfile
{
    public ServiceProfile()
    {
        GetServiceByIDMapping();
        GetServiceListMapping();
        GetServiceListByCompanyIDMapping();
        AddServiceCommandMapping();
        UpdateServiceCommandMapping();
    }
}
