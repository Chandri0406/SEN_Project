using Microsoft.AspNetCore.Mvc;

namespace ApexCareSolutions.Controller
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
