using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Pages.Client
{
    public class complaintModel : PageModel
    {
        [BindProperty]
        public Complaint complaint { get; set; }

        public bool IsComplaintSent { get; set; } = false;  // Track form submission success

        /*public void OnPost()
        {
            DBConnection db = new DBConnection();
            db.addComplaint(complaint);
            //Console.WriteLine(complaint.ToString());  add a breakpoint to this
        }*/

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                // Log or debug ModelState errors if needed
                return Page();
            }

            try
            {
                DBConnection db = new DBConnection();
                db.addComplaint(complaint);
                IsComplaintSent = true;  // Mark success
                return Page();  // Re-render the page to show success message
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding complaint: " + ex.Message);
                ModelState.AddModelError(string.Empty, "An error occurred while sending the complaint.");
                return Page();  // Stay on the same page if there's an error
            }
        }

    }
}