﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Npgsql;
using NpgsqlTypes;

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

        /* public void addComplaint(Complaint complaint)
        {
            // Add complaint to database
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_addcomplaint", connection);
                command.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter issueIDParam = new NpgsqlParameter("p_IssueID", NpgsqlDbType.Text);
                issueIDParam.Value = complaint.IssueID;
                command.Parameters.Add(issueIDParam);

                NpgsqlParameter dateReportedParam = new NpgsqlParameter("p_DateReported", NpgsqlDbType.Date);
                dateReportedParam.Value = complaint.DateReported;
                command.Parameters.Add(dateReportedParam);

                NpgsqlParameter descriptionParam = new NpgsqlParameter("p_Description", NpgsqlDbType.Text);
                descriptionParam.Value = complaint.Description;
                command.Parameters.Add(descriptionParam);

                command.ExecuteNonQuery();
            }

        }
        */
        public void addComplaint(Complaint complaint)
        {
            try
            {
                // Add complaint to the database
                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Define the stored procedure command
                    using (NpgsqlCommand command = new NpgsqlCommand("sp_addcomplaint", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("p_clientid", NpgsqlDbType.Integer, complaint.ClientID);
                        command.Parameters.AddWithValue("p_issueid", NpgsqlDbType.Text, complaint.IssueID);
                        command.Parameters.AddWithValue("p_datereported", NpgsqlDbType.Date, complaint.DateReported);
                        command.Parameters.AddWithValue("p_dateresolved", NpgsqlDbType.Date, complaint.DateResolved);
                        command.Parameters.AddWithValue("p_description", NpgsqlDbType.Text, complaint.Description);

                        // Execute the stored procedure
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the error appropriately
                Console.WriteLine("Error adding complaint: " + ex.Message);
                throw;
            }
        }

        public void addFeedback(Feedback feedback) 
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_addfeedback", connection);
                command.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter issueIDParam = new NpgsqlParameter("p_IssueID", NpgsqlDbType.Text);
                issueIDParam.Value = feedback.IssueID;
                command.Parameters.Add(issueIDParam);

                NpgsqlParameter ratingParam = new NpgsqlParameter("p_DateReported", NpgsqlDbType.Date);
                ratingParam.Value = feedback.Rating;
                command.Parameters.Add(ratingParam);

                NpgsqlParameter dateProvidedParam = new NpgsqlParameter("p_DateReported", NpgsqlDbType.Date);
                dateProvidedParam.Value = feedback.DateProvided;
                command.Parameters.Add(dateProvidedParam);

                NpgsqlParameter commentsParam = new NpgsqlParameter("p_Description", NpgsqlDbType.Text);
                commentsParam.Value = feedback.Comments;
                command.Parameters.Add(commentsParam);

                command.ExecuteNonQuery();
            }
            
        }

    }
}