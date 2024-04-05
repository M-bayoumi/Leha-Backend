namespace Leha.Core.Mapping.Clients;


public partial class ClientProfile
{
    public ClientProfile()
    {
        GetClientByIDMapping();
        GetClientListMapping();
        GetClientListByCompanyIDMapping();
        AddClientCommandMapping();
        UpdateClientCommandMapping();
    }
}
