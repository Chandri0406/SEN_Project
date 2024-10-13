using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages.Agent
{
    public class addIssueModel : PageModel
    {
        public IIssue addIssue { get; set; }
        public void OnGet()
        {
        }
    }
}
