using ApexCareSolutions.Models;

public interface IClientRepository
{
    Clients GetClientById(int clientId);
    void AddClient(Clients client);
    void UpdateClient(Clients client);
    void DeleteClient(int clientId);
}
