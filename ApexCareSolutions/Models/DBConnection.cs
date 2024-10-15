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
            try
            {
                // Add complaint to the database
                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Define the stored procedure command
                    using (NpgsqlCommand command = new NpgsqlCommand("sp_addfeedback", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        command.Parameters.AddWithValue("p_clientid", NpgsqlDbType.Integer, feedback.ClientID);
                        command.Parameters.AddWithValue("p_issueid", NpgsqlDbType.Text, feedback.IssueID);
                        command.Parameters.AddWithValue("p_rating", NpgsqlDbType.Integer, feedback.Rating);
                        command.Parameters.AddWithValue("p_comments", NpgsqlDbType.Text, feedback.Comments);
                        command.Parameters.AddWithValue("p_dateprovided", NpgsqlDbType.Date, feedback.DateProvided);

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

        public void InsertUser(User user, Clients clients)
        {
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {
                    connection.Open();
                    using (NpgsqlCommand command = new NpgsqlCommand("sp_insertclient", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Hash the password before storing (Enable this later)
                        // string hashedPassword = HashPassword(user.Password);  

                        // Add parameters
                        command.Parameters.AddWithValue("p_firstname", NpgsqlDbType.Text, clients.FirstName);
                        command.Parameters.AddWithValue("p_lastname", NpgsqlDbType.Text, clients.LastName);
                        command.Parameters.AddWithValue("p_phone", NpgsqlDbType.Text, clients.Phone);
                        command.Parameters.AddWithValue("p_email", NpgsqlDbType.Text, clients.Email);
                        command.Parameters.AddWithValue("p_address", NpgsqlDbType.Text, clients.Address);
                        command.Parameters.AddWithValue("p_username", NpgsqlDbType.Text, clients.Username);

                        // Use hashedPassword instead of user.Password when enabling hashing
                        command.Parameters.AddWithValue("p_password", NpgsqlDbType.Text, user.Password);

                        // Execute the stored procedure
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error adding user: " + e.Message);
            }
        }

    }
}