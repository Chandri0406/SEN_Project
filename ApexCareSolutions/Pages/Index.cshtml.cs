using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages
{
    public class IndexModel : PageModel
    {
        private DBConnection _dbconn;
        public User user { get; set; }

        public void OnGet()
        {
            if (ModelState.IsValid)
            {
                // Fetch the full user details by username
                var userDetails = _dbconn.GetUserDetails(user.Username);

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
        }
    }
}

