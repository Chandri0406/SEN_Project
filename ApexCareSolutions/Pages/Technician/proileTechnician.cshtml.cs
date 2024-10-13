using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages.Technician
{
    public class proileTechnicianModel : PageModel
    {
        [BindProperty]
        public string technicianID { get; set; }

        [BindProperty]
        public string UserName { get; set; }

        [BindProperty]
        public string firstName { get; set; }

        [BindProperty]
        public string lastName { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public string Email { get; set; }

        public void OnGet()
        {
        }
    }
}
