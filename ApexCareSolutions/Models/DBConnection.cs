using System;
using System.Data;
using System.Text;
using Npgsql;
using NpgsqlTypes;
//using System.Security.Cryptography;  // Add this for SHA256

namespace ApexCareSolutions.Models
{
    public class DBConnection
    {
        private readonly string _connectionString;

        public DBConnection()
        {
            _connectionString = $"Host=localhost;Database=ApexCareDB;Username=Tester;Password=5432;";
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
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



