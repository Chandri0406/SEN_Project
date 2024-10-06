using ApexCareSolutions.Models;
using ApexCareSolutions.Repositories;
using System.Web.Mvc;

namespace ApexCareSolutions.Controllers
{
    public class CallLogController : Controller
    {
        private readonly ICallLogRepository _callLogRepository;

        public CallLogController(ICallLogRepository callLogRepository)
        {
            _callLogRepository = callLogRepository;
        }

        // GET: CallLog
        public ActionResult Index()
        {
            var callLogs = _callLogRepository.GetAllCallLogs(); // Assuming you have a method to get all call logs
            return View(callLogs); // Returns the Index view with the list of call logs
        }

        // GET: CallLog/Create
        public ActionResult Create()
        {
            return View(); // Returns the Create view
        }

        // POST: CallLog/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CallLog callLog)
        {
            if (ModelState.IsValid)
            {
                _callLogRepository.AddCallLog(callLog); // Assuming a method to add a call log
                return RedirectToAction("Index"); // Redirect to the Index action after creation
            }
            return View(callLog); // Returns the Create view with validation errors
        }

        // GET: CallLog/Edit/{id}
        public ActionResult Edit(int id)
        {
            var callLog = _callLogRepository.GetCallLogById(id); // Assuming a method to get a call log by ID
            if (callLog == null)
            {
                return HttpNotFound(); // Return 404 if the call log is not found
            }
            return View(callLog); // Returns the Edit view with the call log data
        }

        // POST: CallLog/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CallLog callLog)
        {
            if (ModelState.IsValid)
            {
                _callLogRepository.UpdateCallLog(callLog); // Assuming a method to update a call log
                return RedirectToAction("Index"); // Redirect to the Index action after update
            }
            return View(callLog); // Returns the Edit view with validation errors
        }

        // GET: CallLog/Details/{id}
        public ActionResult Details(int id)
        {
            var callLog = _callLogRepository.GetCallLogById(id); // Assuming a method to get a call log by ID
            if (callLog == null)
            {
                return HttpNotFound(); // Return 404 if the call log is not found
            }
            return View(callLog); // Returns the Details view with the call log data
        }
    }
}
