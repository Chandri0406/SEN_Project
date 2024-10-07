using Microsoft.AspNetCore.Mvc;

namespace ApexCareSolutions.Controller
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
