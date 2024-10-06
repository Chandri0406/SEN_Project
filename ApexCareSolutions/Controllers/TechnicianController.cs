using Microsoft.AspNetCore.Mvc;
using ApexCareSolutions.Models;
using System.Linq;

namespace ApexCareSolutions.Controllers
{
    public class TechnicianController : Controller
    {
        public ActionResult Technician()
        {
            return View();
        }
    }
}
