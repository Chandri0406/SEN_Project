using Microsoft.AspNetCore.Mvc;

namespace ApexCareSolutions.Controller
{
    public class ComplaintController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
