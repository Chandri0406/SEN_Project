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
                        if(contract is WarrantyContract ct1)
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
                        command.Parameters.AddWithValue("p_username", NpgsqlDbType.Text, user.Username);
                        command.Parameters.AddWithValue("p_password", NpgsqlDbType.Text, user.Password);
                        command.Parameters.AddWithValue("p_firstname", NpgsqlDbType.Text, clients.FirstName);
                        command.Parameters.AddWithValue("p_lastname", NpgsqlDbType.Text, clients.LastName);
                        command.Parameters.AddWithValue("p_phone", NpgsqlDbType.Text, clients.Phone);
                        command.Parameters.AddWithValue("p_email", NpgsqlDbType.Text, clients.Email);
                        command.Parameters.AddWithValue("p_address", NpgsqlDbType.Text, clients.Address);

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