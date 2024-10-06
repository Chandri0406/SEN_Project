using ApexCareSolutions.Models;
using System.Collections.Generic;

namespace ApexCareSolutions.Repositories
{
    public interface IClientRepository
    {
        IEnumerable<Clients> GetAllClients();
        Clients GetClientById(int id);
        void AddClient(Clients client);
        void UpdateClient(Clients client);
        void DeleteClient(int id);
    }
}
