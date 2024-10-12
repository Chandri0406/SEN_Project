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

    }
}