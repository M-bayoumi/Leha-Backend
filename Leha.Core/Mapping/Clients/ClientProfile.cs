namespace Leha.Core.Mapping.Clients;


public partial class ClientProfile
{
    public ClientProfile()
    {
        GetClientListMapping();
        GetClientByIdMapping();
        GetClientDetailsMapping();
        GetClientListByCompanyIDMapping();
        AddClientCommandMapping();
        UpdateClientCommandMapping();
    }
}
