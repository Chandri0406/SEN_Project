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

    }
}