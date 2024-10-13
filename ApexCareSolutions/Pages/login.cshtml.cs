using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages
{
    public class loginModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        public void OnGet()
        {
        }
    }
}
