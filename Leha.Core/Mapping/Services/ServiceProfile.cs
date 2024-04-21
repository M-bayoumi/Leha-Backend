namespace Leha.Core.Mapping.Services;


public partial class ServiceProfile
{
    public ServiceProfile()
    {
        GetServiceByIdMapping();
        GetServiceListMapping();
        GetServiceDetailsMapping();
        GetServiceListByCompanyIDMapping();
        AddServiceCommandMapping();
        UpdateServiceCommandMapping();
    }
}
