using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Pages
{
    public class createUserModel : PageModel
    {
        [BindProperty]
        public User user { get; set; }

        [BindProperty]
        public Clients clients { get; set; }

        // Properties to hold confirm values from the form
        [BindProperty]
        public string ConfirmEmail { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        // Error message to display on the form
        public string ErrorMessage { get; set; }

        public void OnPost()
        {
            // Validate password confirmation
            if (user.Password != ConfirmPassword)
            {
                ErrorMessage = "Passwords do not match!";
            }

            // Validate email confirmation
            if (clients.Email != ConfirmEmail)
            {
                ErrorMessage = "Emails do not match!";
            }

            // If validation passes, insert the user into the database
            DBConnection db = new DBConnection();
            db.InsertUser(user, clients);
        }
    }
}
