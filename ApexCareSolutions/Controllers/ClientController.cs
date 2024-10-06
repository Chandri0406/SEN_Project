using Microsoft.AspNetCore.Mvc; // Importing ASP.NET MVC core library for handling web requests
using ApexCareSolutions.Models; // Importing models used in the application
using ApexCareSolutions.Repositories; // Importing repository interfaces for data access

namespace ApexCareSolutions.Controllers // Namespace for organizing related classes
{
    public class ClientController : Controller // ClientController inherits from the base Controller class
    {
        private readonly IClientRepository _clientRepository; // Repository interface for client data
        private readonly IContractRepository _contractRepository; // Repository interface for contract data

        // Constructor that accepts dependencies for client and contract repositories.
        // This allows for better code organization and testing by injecting the required services.
        public ClientController(IClientRepository clientRepository, IContractRepository contractRepository)
        {
            _clientRepository = clientRepository; // Assigning the injected client repository to the private field
            _contractRepository = contractRepository; // Assigning the injected contract repository to the private field
        }

        // GET: Client/Profile
        // Action method to display the client's profile based on the provided clientId
        public IActionResult Profile(int clientId)
        {
            var client = _clientRepository.GetClientById(clientId); // Fetching the client details by ID
            if (client == null) // Checking if the client was found
            {
                return NotFound(); // Returning a 404 Not Found response if the client does not exist
            }
            return View(client); // Returning the client's profile view with the client data
        }

        // GET: Client/Contracts
        // Action method to display the contract history for a specific client
        public IActionResult ContractHistory(int clientId)
        {
            var contracts = _contractRepository.GetContractsByClientId(clientId); // Fetching contracts associated with the client
            return View(contracts); // Returning the contract history view with the contract data
        }

        // GET: Client/OngoingContracts
        // Action method to display the ongoing contracts for a specific client
        public IActionResult OngoingContracts(int clientId)
        {
            var ongoingContracts = _contractRepository.GetOngoingContractsByClientId(clientId); // Fetching ongoing contracts
            return View(ongoingContracts); // Returning the ongoing contracts view with the contract data
        }

        // POST: Client/ReportIssue
        // Action method to handle issue reporting by the client
        [HttpPost] // Indicates that this method responds to POST requests
        public IActionResult ReportIssue(int clientId, string issueDescription)
        {
            if (string.IsNullOrWhiteSpace(issueDescription)) // Validating that the issue description is not empty
            {
                return BadRequest("Issue description cannot be empty."); // Returning a 400 Bad Request response if empty
            }

            // Calling the repository method to handle the issue reporting for the client
            _clientRepository.ReportIssue(clientId, issueDescription);

            // Redirecting the client back to their profile after reporting the issue
            return RedirectToAction("Profile", new { clientId });
        }
    }
}
