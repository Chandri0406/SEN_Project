using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages
{
    public class createUserModel : PageModel
    {
        public User user { get; set; }
        public Clients clients { get; set; }
        
        //temproary variable to store the email and password
        [BindProperty]
       
        public string ConfirmEmail { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }


        public void OnGet()
        {
        }
    }
}
