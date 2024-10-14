using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages.Agent
{
    public class profileAgentModel : PageModel
    {
        public ServiceAgent serviceAgent { get; set; }
        private readonly DBConnection _dbConnection;

        public void OnGet(string agentID)
        {
            if (!string.IsNullOrEmpty(agentID))
            {
                if (_dbConnection != null)
                {
                    serviceAgent = _dbConnection.GetAgentById(agentID);
                    if (serviceAgent == null)
                    {
                        Console.WriteLine("No agent found with ID: " + agentID);
                    }
                    else
                    {
                        Console.WriteLine("Agent found: " + serviceAgent.Username);
                    }
                }
                else
                {
                    Console.WriteLine("Database connection is not initialized.");
                }
            }
        }


    }
}