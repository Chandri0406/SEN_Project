using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Pages.Client
{
    public class feedbackModel : PageModel
    {
        public Feedback feedback { get; set; }
        public void OnGet()
        {
        }
    }
}
