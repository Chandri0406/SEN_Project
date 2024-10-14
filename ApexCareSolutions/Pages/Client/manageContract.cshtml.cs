using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages.Client
{
    public class manageContractModel : Pages_Client_manageContract
    {

		[BindProperty]
		public CommercialContract commercialContract { get; set; }

		public void OnGet()
        {
        }
    }
}
