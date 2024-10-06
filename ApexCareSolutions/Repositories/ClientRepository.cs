using System;
using ApexCareSolutions.Models;
using Npgsql;

public class ClientRepository : IClientRepository
{
    private readonly DBConnection _dbConnection;

    public ClientRepository()
    {
        _dbConnection = new DBConnection();
    }

    public Clients GetClientById(int clientId)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM Clients WHERE ClientID = @ClientID", connection))
                {
                    cmd.Parameters.AddWithValue("@ClientID", clientId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Clients
                            {
                                ClientID = (int)reader["ClientID"],
                                Username = reader["Username"].ToString(),
                                FirstName = reader["FirstName"].ToString(),
                                LastName = reader["LastName"].ToString(),
                                Address = reader["Address"].ToString(),
                                Phone = reader["Phone"].ToString(),

                            };
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching client: {ex.Message}");
        }
        return null;
    }

    public void AddClient(Clients client)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO Clients (Name, Email, Phone) VALUES (@Name, @Email, @Phone)", connection))
                {
                    cmd.Parameters.AddWithValue("@Name", client.Name);
                    cmd.Parameters.AddWithValue("@Email", client.Email);
                    cmd.Parameters.AddWithValue("@Phone", client.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding client: {ex.Message}");
        }
    }

    public void UpdateClient(Clients client)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("UPDATE Clients SET Name = @Name, Email = @Email, Phone = @Phone WHERE ClientID = @ClientID", connection))
                {
                    cmd.Parameters.AddWithValue("@ClientID", client.ClientID);
                    cmd.Parameters.AddWithValue("@Name", client.Name);
                    cmd.Parameters.AddWithValue("@Email", client.Email);
                    cmd.Parameters.AddWithValue("@Phone", client.Phone);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating client: {ex.Message}");
        }
    }

    public void DeleteClient(int clientId)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("DELETE FROM Clients WHERE ClientID = @ClientID", connection))
                {
                    cmd.Parameters.AddWithValue("@ClientID", clientId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting client: {ex.Message}");
        }
    }
}
