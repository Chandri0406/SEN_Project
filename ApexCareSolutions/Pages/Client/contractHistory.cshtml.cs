using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages.Client
{
    public class contractHistoryModel : PageModel
    {
        [BindProperty]
        public Clients client { get; set; }
        public IContract contract { get; set; }
        public string Type;
        public String Residency;
        private ContractFactory CF { get; set; }
        public List<IContract> contracts { get; set; }

        public void TestData()
        {
            client = new Clients();
            client.ClientID = 11;
            contract = new PrivateContract(client.ClientID, DateTime.Now.Date, DateTime.Now.AddDays(10).Date, "active", "apartment") { ContractID = 3};
            Type = "warranty";
            Residency = "house";
            contracts = new List<IContract>
            {
                new WarrantyContract(client.ClientID, DateTime.Now.Date, DateTime.Now.AddDays(5).Date, "active", "house"){ContractID = 1},
                new CommercialContract(client.ClientID, DateTime.Now.Date, DateTime.Now.AddDays(15).Date, "on hold", "house"){ContractID = 2},
                contract
            };
        }

        public IActionResult OnGet()
        {
            //To test the page
            TestData();
            return Page();
        }
    }
}
