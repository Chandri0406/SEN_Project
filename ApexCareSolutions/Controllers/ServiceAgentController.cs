using Microsoft.AspNetCore.Mvc;

namespace ApexCareSolutions.Controller
{
    public class ServiceAgentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
