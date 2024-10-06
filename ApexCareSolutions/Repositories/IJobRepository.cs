using System.Collections.Generic;
using ApexCareSolutions.Repositories;

namespace ApexCareSolutions.Repositories
{
    public interface IJobRepository
    {
        // Get all jobs assigned to a specific agent
        IEnumerable<JobRepository> GetJobsByAgentId(string agentId);

        // Get a job by its ID
        JobRepository GetJobById(int jobId);

        // Update job status
        void UpdateJobStatus(int jobId, string newStatus);

        // Escalate or reassign a job
        void EscalateOrReassignJob(int jobId, string action);

        // Close a job
        void CloseJob(int jobId);

        // Add a new job
        void AddJob(JobRepository job);
    }
}
