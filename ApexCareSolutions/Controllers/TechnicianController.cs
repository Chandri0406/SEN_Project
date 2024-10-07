using Microsoft.AspNetCore.Mvc;

namespace ApexCareSolutions.Controller
{
    public class TechnicianController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
