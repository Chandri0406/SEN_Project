using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Reflection;

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

        public string selectedID = "0";

        public void TestData()
        {
            CF = new ContractFactory();
            client = new Clients();
            client.ClientID = 11;
            //contract = new PrivateContract(client.ClientID, DateTime.Now.Date, DateTime.Now.AddDays(10).Date, "active", "apartment") { ContractID = "000003"};
            //Type = "warranty";
            //Residency = "house";
            contracts = new List<IContract>
            {
                new WarrantyContract(client.ClientID, DateTime.Now.Date, DateTime.Now.AddDays(5).Date, "active", "house"){ContractID = "000001"},
                new CommercialContract(client.ClientID, DateTime.Now.Date, DateTime.Now.AddDays(15).Date, "on hold", "house"){ContractID = "000002"},
                new PrivateContract(client.ClientID, DateTime.Now.Date, DateTime.Now.AddDays(10).Date, "active", "apartment") { ContractID = "000003"}
            };
            contract = contracts[0];
            selectedID = contract.ContractID;
            Type = CF.DetermineType(contract);
            Residency = CF.DetermineResidency(contract);
            /*if (contract is WarrantyContract ct1)
            {
                Type = ct1.Type;
                Residency = ct1.Residency;
            }
            else
            {

            }*/
        }

        public string ContractID_Changed(string selectedValue)
        {
            foreach (var con in contracts)
            {
                if (con.ContractID == selectedValue)
                {
                    contract = con;
                    selectedID = con.ContractID;
                }
            }
            return null;
        }

        public IActionResult OnGet()
        {
            //To test the page
            TestData();
            return Page();
        }
    }
}
