using System;
using System.Collections.Generic;
using System.Data;
using Npgsql; // Ensure you have this package installed for PostgreSQL
using ApexCareSolutions.Repositories;

namespace ApexCareSolutions.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly string _connectionString;

        public JobRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<JobRepository> GetJobsByAgentId(string agentId)
        {
            var jobs = new List<JobRepository>();
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM Jobs WHERE AgentID = @agentId", connection);
                command.Parameters.AddWithValue("agentId", agentId);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var job = new Job
                        {
                            JobID = reader.GetInt32(0), // Assuming JobID is the first column
                            // Map other fields
                            // Example: JobTitle = reader.GetString(1), etc.
                        };
                        jobs.Add(job);
                    }
                }
            }
            return jobs;
        }

        public Job GetJobById(int jobId)
        {
            Job job = null;
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT * FROM Jobs WHERE JobID = @jobId", connection);
                command.Parameters.AddWithValue("jobId", jobId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        job = new Job
                        {
                            JobID = reader.GetInt32(0),
                            // Map other fields
                        };
                    }
                }
            }
            return job;
        }

        public void UpdateJobStatus(int jobId, string newStatus)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("UPDATE Jobs SET Status = @newStatus WHERE JobID = @jobId", connection);
                command.Parameters.AddWithValue("newStatus", newStatus);
                command.Parameters.AddWithValue("jobId", jobId);
                command.ExecuteNonQuery();
            }
        }

        public void EscalateOrReassignJob(int jobId, string action)
        {
            // Implement escalation or reassign logic here
        }

        public void CloseJob(int jobId)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("DELETE FROM Jobs WHERE JobID = @jobId", connection);
                command.Parameters.AddWithValue("jobId", jobId);
                command.ExecuteNonQuery();
            }
        }

        public void AddJob(Job job)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO Jobs (JobTitle, AgentID, ...) VALUES (@jobTitle, @agentId, ...)", connection);
                command.Parameters.AddWithValue("jobTitle", job.JobTitle);
                command.Parameters.AddWithValue("agentId", job.AgentID);
                // Add other parameters as needed
                command.ExecuteNonQuery();
            }
        }

        IEnumerable<JobRepository> IJobRepository.GetJobsByAgentId(string agentId)
        {
            throw new NotImplementedException();
        }

        JobRepository IJobRepository.GetJobById(int jobId)
        {
            throw new NotImplementedException();
        }

        public void AddJob(JobRepository job)
        {
            throw new NotImplementedException();
        }
    }
}
