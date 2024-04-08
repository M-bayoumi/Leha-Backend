namespace Leha.Core.Mapping.Clients;


public partial class ClientProfile
{
    public ClientProfile()
    {
        GetClientByIdMapping();
        GetClientListMapping();
        GetClientListByCompanyIDMapping();
        AddClientCommandMapping();
        UpdateClientCommandMapping();
    }
}
