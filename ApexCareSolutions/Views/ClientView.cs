using System;
using System.Collections.Generic;
using System.Linq;
using ApexCareSolutions.Models;
using ApexCareSolutions.Models.Factory;

namespace ApexCareSolutions.Views
{
    public class ClientView
    {
        private readonly IClientRepository _clientRepository;
        private readonly IContractRepository _contractRepository;

        public ClientView(IClientRepository clientRepository, IContractRepository contractRepository)
        {
            // This constructor gets the client and contract data through parameters.
            // It makes the code easier to change and test.
            _clientRepository = clientRepository;
            _contractRepository = contractRepository;
        }

        // Method to get the client's profile details
        public Clients GetClientProfile(int clientId)
        {
            return _clientRepository.GetClientById(clientId);
        }

        // Method to get the contract history for a client
        public List<IContract> GetContractHistory(int clientId)
        {
            return _contractRepository.GetContractsByClientId(clientId).ToList();
        }

        // Method to get the ongoing contracts for a client
        public List<IContract> GetOngoingContracts(int clientId)
        {
            return _contractRepository.GetOngoingContractsByClientId(clientId).ToList();
        }

        // Method to report an issue for a client
        public bool ReportIssue(int clientId, string issueDescription)
        {
            // Assuming there is an Issue model and repository to handle issues
            var issue = new Issue
            {
                ClientID = clientId,
                Description = issueDescription,
                ReportedDate = DateTime.UtcNow
            };

            return _clientRepository.ReportIssue(issue);
        }
    }
}
