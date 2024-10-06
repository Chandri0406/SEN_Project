using System;
using ApexCareSolutions.Models;
using Npgsql;

public class ServiceAgentRepository : IServiceAgentRepository
{
    private readonly DBConnection _dbConnection;

    public ServiceAgentRepository()
    {
        _dbConnection = new DBConnection();
    }

    public ServiceAgent GetServiceAgentById(string agentId)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM ServiceAgents WHERE AgentID = @AgentID", connection))
                {
                    cmd.Parameters.AddWithValue("@AgentID", agentId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ServiceAgent
                            {
                                AgentID = (string)reader["AgentID"],
                                //Username, FirstName, LastName,Phone,Email
                                Username = (string)reader["Username"],
                                FirstName = (string)reader["FirstName"],
                                LastName = (string)reader["LastName"],
                                Phone = (string)reader["Phone"],
                                Email = (string)reader["Email"],

                            };
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching service agent: {ex.Message}");
        }
        return null;
    }

    public void AddServiceAgent(ServiceAgent serviceAgent)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO ServiceAgents (AgentID, Name, Phone, Email) VALUES (@AgentID, @Name, @Phone, @Email)", connection))
                {
                    cmd.Parameters.AddWithValue("@AgentID", serviceAgent.AgentID);
                    cmd.Parameters.AddWithValue("@Name", serviceAgent.Name);
                    cmd.Parameters.AddWithValue("@Phone", serviceAgent.Phone);
                    cmd.Parameters.AddWithValue("@Email", serviceAgent.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding service agent: {ex.Message}");
        }
    }

    public void UpdateServiceAgent(ServiceAgent serviceAgent)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("UPDATE ServiceAgents SET Name = @Name, Phone = @Phone, Email = @Email WHERE AgentID = @AgentID", connection))
                {
                    cmd.Parameters.AddWithValue("@AgentID", serviceAgent.AgentID);
                    cmd.Parameters.AddWithValue("@Name", serviceAgent.Name);
                    cmd.Parameters.AddWithValue("@Phone", serviceAgent.Phone);
                    cmd.Parameters.AddWithValue("@Email", serviceAgent.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating service agent: {ex.Message}");
        }
    }

    public void DeleteServiceAgent(string agentId)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM ServiceAgents WHERE AgentID = @AgentID", connection))
                {
                    cmd.Parameters.AddWithValue("@AgentID", agentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting service agent: {ex.Message}");
        }
    }
}
