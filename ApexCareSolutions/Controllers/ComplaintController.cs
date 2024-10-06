using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Controllers
{
    public class ComplaintController
    {
        public class ComplaintController : Controller
        {
            // In-memory storage for demonstration (replace with DB context)
            private static List<Complaint> complaints = new List<Complaint>();

            // GET: Complaint/Index
            public ActionResult Index()
            {
                return View(complaints);
            }

            // GET: Complaint/Create
            public ActionResult Create()
            {
                return View();
            }

            // POST: Complaint/Create
            [HttpPost]
            public ActionResult Create(Complaint complaint)
            {
                if (ModelState.IsValid)
                {
                    complaints.Add(complaint);
                    return RedirectToAction("Index");
                }
                return View(complaint);
            }

            // GET: Complaint/Edit/{id}
            public ActionResult Edit(int id)
            {
                var complaint = complaints.FirstOrDefault(c => c.ComplaintID == id);
                if (complaint == null)
                {
                    return HttpNotFound();
                }
                return View(complaint);
            }

            // POST: Complaint/Edit/{id}
            [HttpPost]
            public ActionResult Edit(Complaint complaint)
            {
                if (ModelState.IsValid)
                {
                    var originalComplaint = complaints.FirstOrDefault(c => c.ComplaintID == complaint.ComplaintID);
                    if (originalComplaint != null)
                    {
                        originalComplaint.DateResolved = complaint.DateResolved;
                        originalComplaint.Description = complaint.Description;
                    }
                    return RedirectToAction("Index");
                }
                return View(complaint);
            }

            // GET: Complaint/Delete/{id}
            public ActionResult Delete(int id)
            {
                var complaint = complaints.FirstOrDefault(c => c.ComplaintID == id);
                if (complaint == null)
                {
                    return HttpNotFound();
                }
                return View(complaint);
            }

            // POST: Complaint/Delete/{id}
            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                var complaint = complaints.FirstOrDefault(c => c.ComplaintID == id);
                if (complaint != null)
                {
                    complaints.Remove(complaint);
                }
                return RedirectToAction("Index");
            }
        }
}