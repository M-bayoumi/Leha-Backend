﻿using Leha.Data.Entities;

namespace Leha.Manager.Managers.Clients;

public interface IClientManager
{
    public Task<List<Client?>> GetClientsListAsync();
    public Task<List<Client>?> GetClientsListByCompanyId(int companyID);
    public Task<Client?> GetClientByIDAsync(int clientID);
    public Task<bool> AddClientAsync(Client client);
    public Task<bool> UpdateClientAsync(Client client);
    public Task<bool> DeleteClientAsync(Client client );
}