using Microsoft.AspNetCore.Mvc;

namespace ApexCareSolutions.Controller
{
    public class FeedBackController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
