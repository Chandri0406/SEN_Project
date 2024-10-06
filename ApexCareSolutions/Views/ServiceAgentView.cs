using System;
using System.Collections.Generic;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Views
{
    public class ServiceAgentView
    {
        private readonly IServiceAgentRepository _serviceAgentRepository;
        private readonly IJobRepository _jobRepository;

        public ServiceAgentView(IServiceAgentRepository serviceAgentRepository, IJobRepository jobRepository)
        {
            _serviceAgentRepository = serviceAgentRepository;
            _jobRepository = jobRepository;
        }

        // View all jobs assigned to the service agent
        public void ViewAssignedJobs(int agentId)
        {
            var jobs = _jobRepository.GetJobsByAgentId(agentId);
            Console.WriteLine($"Service Agent ID: {agentId} - Assigned Jobs:");
            foreach (var job in jobs)
            {
                Console.WriteLine($"Job ID: {job.JobId}, Description: {job.Description}, Status: {job.Status}");
            }
        }

        // Update job status
        public void UpdateJobStatus(int jobId, string newStatus)
        {
            var job = _jobRepository.GetJobById(jobId);
            if (job != null)
            {
                job.Status = newStatus;
                _jobRepository.UpdateJob(job);
                Console.WriteLine($"Job ID: {jobId} status updated to {newStatus}");
            }
            else
            {
                Console.WriteLine("Job not found!");
            }
        }

        // Escalate or reassign a job
        public void EscalateOrReassignJob(int jobId, string action)
        {
            var job = _jobRepository.GetJobById(jobId);
            if (job != null)
            {
                if (action == "escalate")
                {
                    job.Status = "Escalated";
                    _jobRepository.UpdateJob(job);
                    Console.WriteLine($"Job ID: {jobId} has been escalated.");
                }
                else if (action == "reassign")
                {
                    // Logic to reassign job to another agent
                    Console.WriteLine($"Job ID: {jobId} has been reassigned.");
                }
            }
            else
            {
                Console.WriteLine("Job not found!");
            }
        }

        // Close job
        public void CloseJob(int jobId)
        {
            var job = _jobRepository.GetJobById(jobId);
            if (job != null)
            {
                job.Status = "Closed";
                _jobRepository.UpdateJob(job);
                Console.WriteLine($"Job ID: {jobId} has been closed.");
            }
            else
            {
                Console.WriteLine("Job not found!");
            }
        }
    }
}
