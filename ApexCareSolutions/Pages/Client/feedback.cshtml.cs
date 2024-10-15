using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Pages.Client
{
    public class feedbackModel : PageModel
    {
        [BindProperty]
        public Feedback feedback { get; set; }

        public bool IsFeedbackSent { get; set; } = false;

        /*public void OnPost() 
        {
            DBConnection db = new DBConnection();
            db.addFeedback(feedback);
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
                db.addFeedback(feedback);
                IsFeedbackSent = true;  // Mark success
                return Page();  // Re-render the page to show success message
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error submitting feedback: " + ex.Message);
                ModelState.AddModelError(string.Empty, "An error occurred while submitting the feedback.");
                return Page();  // Stay on the same page if there's an error
            }
        }

    }
}
