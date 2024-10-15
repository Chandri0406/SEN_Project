using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages.Agent
{
    public class addIssueModel : PageModel
    {
        [BindProperty]
        public IIssue issue { get; set; }
        public string Description;
        public IssueFactory IF { get; set; }

        public void TestData()
        {
            issue = new MalfunctionIssue(13, 17, "000001", "low", "open", DateTime.Now.Date, DateTime.Now.AddDays(10)) { IssueID = "000002" };
            Description = "Malfunction";
        }

        public IActionResult OnGet()
        {
            //Test page
            TestData();
            return Page();
        }

        public void OnPost()
        {
            DBConnection db = new DBConnection();
            db.addIssue(issue);
        }
    }
}