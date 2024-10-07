using Microsoft.AspNetCore.Mvc;

namespace ApexCareSolutions.Controller
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
