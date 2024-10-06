using ApexCareSolutions.Models;
using ApexCareSolutions.Repositories;
using System.Web.Mvc;

namespace ApexCareSolutions.Controllers
{
    public class ServiceAgentController : Controller
    {
        private readonly IServiceAgentRepository _serviceAgentRepository;
        private readonly IJobRepository _jobRepository;

        public ServiceAgentController(IServiceAgentRepository serviceAgentRepository, IJobRepository jobRepository)
        {
            _serviceAgentRepository = serviceAgentRepository;
            _jobRepository = jobRepository;
        }

        // View all jobs assigned to the service agent
        public ActionResult ViewAssignedJobs(string agentId)
        {
            var jobs = _jobRepository.GetJobsByAgentId(agentId); // Retrieve jobs assigned to the agent
            return View("AssignedJobs", jobs); // Pass jobs to the AssignedJobs.cshtml view
        }

        // Update the status of a job
        [HttpPost]
        public ActionResult UpdateJobStatus(int jobId, string newStatus)
        {
            _jobRepository.UpdateJobStatus(jobId, newStatus);
            return RedirectToAction("ViewAssignedJobs", new { agentId = /* current agentId */ });
        }

        // Escalate or reassign a job
        [HttpPost]
        public ActionResult EscalateOrReassignJob(int jobId, string action)
        {
            _jobRepository.EscalateOrReassignJob(jobId, action);
            return RedirectToAction("ViewAssignedJobs", new { agentId = /* current agentId */ });
        }

        // Close a job after completion
        [HttpPost]
        public ActionResult CloseJob(int jobId)
        {
            _jobRepository.CloseJob(jobId);
            return RedirectToAction("ViewAssignedJobs", new { agentId = /* current agentId */ });
        }
    }
}
