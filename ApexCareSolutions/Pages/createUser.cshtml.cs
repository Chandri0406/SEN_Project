using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages
{
    public class createUserModel : PageModel
    {
        [BindProperty]
        public User user { get; set; } = new User();

        [BindProperty]
        public Clients clients { get; set; } = new Clients();

        // Properties to hold confirm values from the form
        [BindProperty]
        public string ConfirmEmail { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        // Error message to display on the form
        public string ErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            // Validate password confirmation
            if (user.Password != ConfirmPassword)
            {
                ErrorMessage = "Passwords do not match!";
                return Page(); // Re-render the page with the error message
            }

            // Validate email confirmation
            if (clients.Email != ConfirmEmail)
            {
                ErrorMessage = "Emails do not match!";
                return Page(); // Re-render the page with the error message
            }

            // If validation passes, insert the user into the database
            DBConnection db = new DBConnection();
            db.InsertUser(user, clients);

            // Redirect to login page after successful signup
            return RedirectToPage("/login");
        }
    }
}
