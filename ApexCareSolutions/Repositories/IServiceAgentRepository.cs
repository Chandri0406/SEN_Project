using ApexCareSolutions.Models;
using System.Collections.Generic;

namespace ApexCareSolutions.Repositories
{
    public interface IServiceAgentRepository
    {
        IEnumerable<ServiceAgent> GetAllServiceAgents();
        ServiceAgent GetServiceAgentById(string id);
        void AddServiceAgent(ServiceAgent agent);
        void UpdateServiceAgent(ServiceAgent agent);
        void DeleteServiceAgent(string id);
    }
}
