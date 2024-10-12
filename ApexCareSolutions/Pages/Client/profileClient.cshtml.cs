using ApexCareSolutions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ApexCareSolutions.Pages.Client
{
    public class profileClientModel : PageModel
    {

        [BindProperty]
        public Clients client { get; set; }

        public void TestData()
        {
            client.Username = "AJones777";
            client.FirstName = "Alex";
            client.LastName = "Jones";
            client.Phone = "011 233 4576";
            client.Email = "AJones777@gmail.com";
            client.Address = "776 Port Avenue Space";
        }

        public IActionResult OnGet()
        {
            //To test the page
            TestData();
            return Page();
        }

        public IActionResult OnPost()
        {
            var newUsername = client.Username;
            var newFirstName = client.FirstName;
            var newLastName = client.LastName;
            var newPhone = client.Phone;
            var newEmail = client.Email;
            var newAddress = client.Address;

            return Content($"{newUsername}; {newFirstName}; {newLastName}; {newPhone}; {newEmail}; {newAddress}");
        }
    }
}
