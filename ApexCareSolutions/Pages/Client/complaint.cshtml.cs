using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Pages.Client
{
    public class complaintModel : PageModel
    {
        public Complaint complaint { get; set; }
        public void OnGet()
        {
        }
    }
}
