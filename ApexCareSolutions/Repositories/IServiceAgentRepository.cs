using ApexCareSolutions.Models;

public interface IServiceAgentRepository
{
    ServiceAgent GetServiceAgentById(string agentId);
    void AddServiceAgent(ServiceAgent serviceAgent);
    void UpdateServiceAgent(ServiceAgent serviceAgent);
    void DeleteServiceAgent(string agentId);
}
