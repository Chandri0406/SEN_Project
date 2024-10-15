using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;
using System.Threading.Tasks;

namespace ApexCareSolutions.Pages
{
    public class loginModel : PageModel
    {
        private readonly DBConnection _dbConnection;

        public loginModel(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        [BindProperty]
        public User User { get; set; } // This is the login form user

        public string ReturnUrl { get; set; } // URL to return to after login

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            ReturnUrl = returnUrl; // Store return URL for later use

            if (ModelState.IsValid)
            {
                // Fetch the full user details by username
                var userDetails = await _dbConnection.GetUserDetails(User.Username);

                if (userDetails != null)
                {
                    // Password check (ensure passwords are hashed in production)
                    if (User.Password == userDetails.Password)
                    {
                        // Debug output
                        Console.WriteLine($"User Role: {userDetails.Role}");

                        // Use a switch case to handle role-based redirection
                        switch (userDetails.Role)
                        {
                            case "Agent":
                                return RedirectToPage("/Agent/profileAgent", new { returnUrl });

                            case "Client":
                                Response.Redirect("/Client/profileClient.cshtml");
                                break;

                            case "Technician":
                                return RedirectToPage("/Technician/profileTechnician", new { returnUrl });

                            default:
                                ModelState.AddModelError(string.Empty, "Unknown role.");
                                break;
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid password.");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "User does not exist.");
                }
            }

            // Log the ModelState errors for debugging
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }

            // Redisplay the form if something failed
            return Page();
        }
    }
}
