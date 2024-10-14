using System;
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

        public Clients GetClientDetails(string username)
        {
            Clients client = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_getclientdetails", connection);
                command.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter usernameParam = new NpgsqlParameter("username", NpgsqlDbType.Text);
                usernameParam.Value = username;
                command.Parameters.Add(usernameParam);

                try
                {
                    connection.Open();
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        client = new Clients();
                        client.ClientID = reader.GetInt32("ClientID");
                        client.Username = reader.GetString("Username");
                        client.FirstName = reader.GetString("FirstName");
                        client.LastName = reader.GetString("LastName");
                        client.Phone = reader.GetString("Phone");
                        client.Email = reader.GetString("Email");
                        client.Address = reader.GetString("Address");
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }

            return client;
        }

        public List<IContract> getClientContracts(int clientid)
        {
            contractFactory = new ContractFactory();
            List<IContract> contracts = new List<IContract>();

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                NpgsqlCommand command = new NpgsqlCommand("sp_getclientcontracts", connection);
                command.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter clientidParam = new NpgsqlParameter("p_clientid", NpgsqlDbType.Integer);
                clientidParam.Value = clientid;
                command.Parameters.Add(clientidParam);

                try
                {
                    NpgsqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        IContract contract;
                        string type = reader.GetString(5);
                        contract = contractFactory.CreateContract(type);
                        string residency = reader.GetString(6);
                        string contractid = reader.GetString(0);
                        DateTime startdate = reader.GetDateTime(2);
                        DateTime enddate = reader.GetDateTime(3);
                        string status = reader.GetString(4);
                        //string address = reader.GetString(7);
                        if (contract is WarrantyContract ct1)
                        {
                            ct1.ContractID = contractid;
                            ct1.ClientID = clientid;
                            ct1.StartDate = startdate;
                            ct1.EndDate = enddate;
                            ct1.Status = status;
                            ct1.Residency = residency;

                            contracts.Add(ct1);
                        }
                        if (contract is WarrantyContract ct2)
                        {
                            ct2.ContractID = contractid;
                            ct2.ClientID = clientid;
                            ct2.StartDate = startdate;
                            ct2.EndDate = enddate;
                            ct2.Status = status;
                            ct2.Residency = residency;

                            contracts.Add(ct2);
                        }
                        if (contract is CommercialContract ct3)
                        {
                            ct3.ContractID = contractid;
                            ct3.ClientID = clientid;
                            ct3.StartDate = startdate;
                            ct3.EndDate = enddate;
                            ct3.Status = status;
                            ct3.Residency = residency;

                            contracts.Add(ct3);
                        }
                    }

                    reader.Close();

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return contracts;
        }

        public void addIssue(IIssue issue)
        {
            issueFactory = new IssueFactory();
            try
            {

                using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
                {

                    connection.Open();


                    using (NpgsqlCommand command = new NpgsqlCommand("sp_addissue", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        command.Parameters.AddWithValue("p_clientid", NpgsqlDbType.Integer, issue.ClientID);
                        command.Parameters.AddWithValue("p_contractid", NpgsqlDbType.Text, issue.ContractID);
                        command.Parameters.AddWithValue("p_callid", NpgsqlDbType.Integer, issue.CallID);
                        command.Parameters.AddWithValue("p_priority", NpgsqlDbType.Text, issue.Priority);
                        command.Parameters.AddWithValue("p_status", NpgsqlDbType.Text, issue.Status);
                        command.Parameters.AddWithValue("p_startdate", NpgsqlDbType.Date, issue.StartDate);
                        command.Parameters.AddWithValue("p_startdate", NpgsqlDbType.Date, issue.StartDate);
                        command.Parameters.AddWithValue("p_description", NpgsqlDbType.Text, issueFactory.DetermineType(issue));

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error adding complaint: " + ex.Message);
                throw;
            }
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

        // Commented-out hashing method for now
        /*
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
        */
        public ServiceAgent GetAgentById(string agentID)
        {
            ServiceAgent serviceAgent = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(_connectionString))
            {
                NpgsqlCommand command = new NpgsqlCommand("sp_getagents", connection);
                command.CommandType = CommandType.StoredProcedure;

                NpgsqlParameter agentIdParam = new NpgsqlParameter("agent_id", NpgsqlDbType.Text);
                agentIdParam.Value = agentID;
                command.Parameters.Add(agentIdParam);

                try
                {
                    connection.Open();
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            serviceAgent = new ServiceAgent
                            {
                                AgentID = reader.GetString("agentID"),
                                Username = reader.GetString("username"),
                                FirstName = reader.GetString("firstname"),
                                LastName = reader.GetString("lastname"),
                                Phone = reader.GetString("phone"),
                                Email = reader.GetString("email")
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return serviceAgent;
        }


    }
}