using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApexCareSolutions.Models;
using System.Threading.Tasks;

namespace ApexCareSolutions.Pages.Technician
{
    public class proileTechnicianModel : PageModel
    {
        private readonly DBConnection dbConnection;

        public proileTechnicianModel Technician { get; set; }

        /*  Still figuring out why GetTechnicians() isn't working. Chat says use this but nothing
        public ProfileTechnicianModel(DBConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        */

        public async Task<IActionResult> OnGetAsync(string TechnicianID)
        {
            Technician = dbConnection.GetTechnicians(); //No clue what GetTechnicians() is still an Error

            if (Technician == null )
            {
                return NotFound();
            }
            return Page();
        }
    }
}
