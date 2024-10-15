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

        // Properties for confirm fields from the form
        [BindProperty]
        public string ConfirmEmail { get; set; }

        [BindProperty]
        public string ConfirmPassword { get; set; }

        // Error messages to display on the form
        public string PasswordErrorMessage { get; set; }
        public string EmailErrorMessage { get; set; }

        public IActionResult OnPost()
        {
            bool isValid = true;

            // Validate password confirmation
            if (user.Password != ConfirmPassword)
            {
                PasswordErrorMessage = "Passwords do not match!";
                isValid = false;
            }

            // Validate email confirmation
            if (clients.Email != ConfirmEmail)
            {
                EmailErrorMessage = "Emails do not match!";
                isValid = false;
            }

            // If any validation failed, re-render the page with error messages
            if (!isValid)
            {
                return Page();
            }

            // Insert user into the database if validation passes
            try
            {
                DBConnection db = new DBConnection();
                db.InsertUser(user, clients);

                // Redirect to login page after successful signup
                return RedirectToPage("/login");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while creating the user.");
                return Page();
            }
        }
    }
}
