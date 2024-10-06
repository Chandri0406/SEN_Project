using ApexCareSolutions.Models;
using ApexCareSolutions.Views;

namespace ApexCareSolutions.Controllers
{
    public class ClientController
    {
        private readonly IClientRepository _clientRepository;
        private readonly IContractRepository _contractRepository;
        private readonly ICallLogRepository _callLogRepository;
        private readonly ClientView _clientView;

        public ClientController(IClientRepository clientRepository, IContractRepository contractRepository, ICallLogRepository callLogRepository)
        {
            _clientRepository = clientRepository;
            _contractRepository = contractRepository;
            _callLogRepository = callLogRepository;
            _clientView = new ClientView(_clientRepository, _contractRepository, _callLogRepository); // Initialize the view with the repositories
        }

        // View the client profile
        public void ViewClientProfile(int clientId)
        {
            _clientView.ViewClientProfile(clientId);
        }

        // View the contract history of a client
        public void ViewContractHistory(int clientId)
        {
            _clientView.ViewContractHistory(clientId);
        }

        // Report an issue
        public void ReportIssue(int clientId, string issueDescription)
        {
            _clientView.ReportIssue(clientId, issueDescription);
        }

        // View ongoing contracts for a client
        public void ViewOngoingContracts(int clientId)
        {
            _clientView.ViewOngoingContracts(clientId);
        }
    }
}
