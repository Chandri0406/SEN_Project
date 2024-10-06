using System;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Views
{
    public class ClientView
    {
        private readonly IClientRepository _clientRepository;
        private readonly IContractRepository _contractRepository;
        private readonly ICallLogRepository _callLogRepository;

        public ClientView(IClientRepository clientRepository, IContractRepository contractRepository, ICallLogRepository callLogRepository)
        {
            _clientRepository = clientRepository;
            _contractRepository = contractRepository;
            _callLogRepository = callLogRepository;
        }

        // View client profile details
        public void ViewClientProfile(int clientId)
        {
            var client = _clientRepository.GetClientById(clientId);
            if (client != null)
            {
                Console.WriteLine($"Client ID: {client.ClientId}, Name: {client.Name}, Email: {client.Email}");
            }
            else
            {
                Console.WriteLine("Client not found!");
            }
        }

        // View client contract history
        public void ViewContractHistory(int clientId)
        {
            var contracts = _contractRepository.GetContractsByClientId(clientId);
            Console.WriteLine($"Client ID: {clientId} - Contract History:");
            foreach (var contract in contracts)
            {
                Console.WriteLine($"Contract ID: {contract.ContractId}, Type: {contract.ContractType}, Status: {contract.Status}");
            }
        }

        // Report an issue
        public void ReportIssue(int clientId, string issueDescription)
        {
            _clientRepository.ReportIssue(clientId, issueDescription);
            Console.WriteLine($"Issue reported for Client ID: {clientId}, Description: {issueDescription}");
        }

        // View ongoing contracts
        public void ViewOngoingContracts(int clientId)
        {
            var contracts = _contractRepository.GetOngoingContractsByClientId(clientId);
            Console.WriteLine($"Client ID: {clientId} - Ongoing Contracts:");
            foreach (var contract in contracts)
            {
                Console.WriteLine($"Contract ID: {contract.ContractId}, Type: {contract.ContractType}, Status: {contract.Status}");
            }
        }
    }
}
