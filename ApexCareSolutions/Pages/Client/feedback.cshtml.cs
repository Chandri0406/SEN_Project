using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages.Client
{
    public class feedbackModel : PageModel
    {
        public Feedback feedback { get; set; }

        public void OnPost()
        {
            DBConnection db = new DBConnection();
            db.addFeedback(feedback);
        }
    }
}
