using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Controllers
{
    public class FeedbackController
    {
        // In-memory storage for demonstration (should be replaced with a database in real-world applications)
        private static List<Feedback> feedbacks = new List<Feedback>();

        // GET: Feedback/Index
        public ActionResult Index()
        {
            return View(feedbacks);
        }

        // GET: Feedback/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Feedback/Create
        [HttpPost]
        public ActionResult Create(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                feedbacks.Add(feedback);
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        // GET: Feedback/Edit/{id}
        public ActionResult Edit(int id)
        {
            var feedback = feedbacks.FirstOrDefault(f => f.FeedbackID == id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedback/Edit/{id}
        [HttpPost]
        public ActionResult Edit(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                var originalFeedback = feedbacks.FirstOrDefault(f => f.FeedbackID == feedback.FeedbackID);
                if (originalFeedback != null)
                {
                    originalFeedback.Rating = feedback.Rating;
                    originalFeedback.Comments = feedback.Comments;
                    originalFeedback.DateProvided = feedback.DateProvided;
                }
                return RedirectToAction("Index");
            }
            return View(feedback);
        }

        // GET: Feedback/Delete/{id}
        public ActionResult Delete(int id)
        {
            var feedback = feedbacks.FirstOrDefault(f => f.FeedbackID == id);
            if (feedback == null)
            {
                return HttpNotFound();
            }
            return View(feedback);
        }

        // POST: Feedback/Delete/{id}
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var feedback = feedbacks.FirstOrDefault(f => f.FeedbackID == id);
            if (feedback != null)
            {
                feedbacks.Remove(feedback);
            }
            return RedirectToAction("Index");
        }
    }
}