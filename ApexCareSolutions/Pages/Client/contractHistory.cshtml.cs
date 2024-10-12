using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages.Client
{
    public class contractHistoryModel : PageModel
    {
        [BindProperty]
        public Clients client { get; set; }
        public PrivateContract contract { get; set; }
        private ContractFactory cf { get; set; }

        public void TestData()
        {
            client.ClientID = 11;
            contract = new PrivateContract(client.ClientID, DateTime.Now.Date, DateTime.Now.AddDays(10), "active", "apartment");
        }

        public IActionResult OnGet()
        {
            //To test the page
            TestData();
            return Page();
        }
    }
}
