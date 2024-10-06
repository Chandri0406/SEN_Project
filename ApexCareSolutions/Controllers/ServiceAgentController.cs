using ApexCareSolutions.Models;
using ApexCareSolutions.Views;

namespace ApexCareSolutions.Controllers
{
    public class ServiceAgentController
    {
        private readonly IServiceAgentRepository _serviceAgentRepository;
        private readonly IJobRepository _jobRepository;
        private readonly ServiceAgentView _serviceAgentView;

        public ServiceAgentController(IServiceAgentRepository serviceAgentRepository, IJobRepository jobRepository)
        {
            _serviceAgentRepository = serviceAgentRepository;
            _jobRepository = jobRepository;
            _serviceAgentView = new ServiceAgentView(_serviceAgentRepository, _jobRepository); // Initialize the view with the repositories
        }

        // View all jobs assigned to the service agent
        public void ViewAssignedJobs(int agentId)
        {
            _serviceAgentView.ViewAssignedJobs(agentId);
        }

        // Update the status of a job
        public void UpdateJobStatus(int jobId, string newStatus)
        {
            _serviceAgentView.UpdateJobStatus(jobId, newStatus);
        }

        // Escalate or reassign a job
        public void EscalateOrReassignJob(int jobId, string action)
        {
            _serviceAgentView.EscalateOrReassignJob(jobId, action);
        }

        // Close a job after completion
        public void CloseJob(int jobId)
        {
            _serviceAgentView.CloseJob(jobId);
        }
    }
}
