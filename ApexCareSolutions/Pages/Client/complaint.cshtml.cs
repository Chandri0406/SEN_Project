using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Pages.Client
{
    public class complaintModel : PageModel
    {
        [BindProperty]
        public Complaint complaint { get; set; }
        
        public void OnPost()
        {
            DBConnection db = new DBConnection();
            db.addComplaint(complaint);
            /*Console.WriteLine(complaint.ToString());  add a breakpoint to this*/
        }
    }
}
