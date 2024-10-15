using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ApexCareSolutions.Pages.Client
{
    public class contractDetailsModel : Pages_Client_contractDetails
    {
        [BindProperty]
        public Clients clients { get; set; }
        public CommercialContract commercialContract { get; set; }


        public void OnGet()
        {
        }
    }
}