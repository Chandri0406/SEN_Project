using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages.Technician
{
    public class ongoingJobsModel : PageModel
    {
        public List<Technician> Technicians { get; set; }

        [BindProperty]
        public string clientUsername { get; set; }

        [BindProperty]
        public int IssueID { get; set; }

        [BindProperty]
        public int SelectedTechnicianID { get; set; }

        [BindProperty]
        public DateTime startDate { get; set; }

        [BindProperty]
        public DateTime endDate { get; set; }

        public void OnGet()
        {
        
        }

        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
