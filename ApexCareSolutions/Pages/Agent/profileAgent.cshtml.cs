using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages.Agent
{
    public class profileAgentModel : PageModel
    {
        public ServiceAgent serviceAgent { get; set; }
        public void OnGet()
        {
        }
    }
}
