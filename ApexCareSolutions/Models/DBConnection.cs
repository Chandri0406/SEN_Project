using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace ApexCareSolutions.Models
{
    public class DBConnection
    {
        private readonly string _connectionString;
        private ContractFactory contractFactory;
        private IssueFactory issueFactory;

        public DBConnection()
        {
            _connectionString = $"Host=localhost;Database=ApexCareDB;Username=Tester;Password=5432;";
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public List<Feedback> GetFeedbacks()
        {
            List<Feedback> feedbacks = new List<Feedback>();
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT * FROM public.tb_ServiceFeedback", connection);
                try
                {
                    connection.Open(); NpgsqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Feedback feedback = new Feedback();
                        feedback.FeedbackID = reader.GetInt32(0);
                        feedback.ClientID = reader.GetInt32(1);
                        feedback.IssueID = reader.GetInt32(2);
                        feedback.Rating = reader.GetInt32(3);
                        feedback.Comments = reader.GetString(4);
                        feedback.DateProvided = reader.GetDateTime(5);
                        feedbacks.Add(feedback);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Handle exceptions appropriately
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                { connection.Close(); }
            }
            return feedbacks;
        }
        // Method to get the total number of service agents
        public int GetTotalServiceAgents()
        {
            int totalServiceAgents = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM public.tb_ServiceAgents", connection);

                try
                {
                    connection.Open();
                    totalServiceAgents = Convert.ToInt32(command.ExecuteScalar()); 
                }
                catch (Exception ex)
                {
                    // Handle exceptions appropriately
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return totalServiceAgents;
        }



        //Method to get the total number of contracts.
        public int GetTotalContracts()
        {
            int totalContracts = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM public.tb_Contracts", connection);

                try
                {
                    connection.Open();
                    totalContracts = Convert.ToInt32(command.ExecuteScalar()); // Gets the total number of contracts
                }
                catch (Exception ex)
                {
                    // Handle exceptions appropriately
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return totalContracts;
        }


        public int GetTotalTechnicians()
        {
            int totalTechnicians = 0;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("SELECT COUNT(*) FROM public.tb_Technicians", connection);

                try
                {
                    connection.Open();
                    totalTechnicians = Convert.ToInt32(command.ExecuteScalar()); // Gets the total number of technicians
                }
                catch (Exception ex)
                {
                    // Handle exceptions appropriately
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return totalTechnicians;
        }

    }
}