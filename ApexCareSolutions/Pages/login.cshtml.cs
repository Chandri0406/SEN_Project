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
        public User user { get; set; } // This is the login form user

        public string ReturnUrl { get; set; } // URL to return to after login

        public IActionResult OnPost(string returnUrl = null)
        {
            ReturnUrl = returnUrl; // Store return URL for later use

            if (ModelState.IsValid)
            {
                // Fetch the full user details by username
                var userDetails = _dbConnection.GetUserDetails(user.Username);

                if (userDetails != null)
                {
                    // Password check (ensure passwords are hashed in production)
                    if (user.Password == userDetails.Password)
                    {
                        
                        switch (userDetails.Role)
                        {
                            case "Agent":
                                Response.Redirect("/Agent/profileAgent.cshtml");
                                break;

                            case "Client":
                                Response.Redirect("/Client/profileClient.cshtml");
                                break;

                            case "Technician":
                                Response.Redirect("/Technician/profileTecnician.cshtml");
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

            return Page();
        }
    }
}