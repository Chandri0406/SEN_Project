using System;
using System.Collections.Generic;
using ApexCareSolutions.Models;
using Npgsql;

public class CallLogRepository : ICallLogRepository
{
    private readonly DBConnection _dbConnection;

    public CallLogRepository()
    {
        _dbConnection = new DBConnection();
    }

    public CallLog GetCallLogById(int callId)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM CallLogs WHERE CallID = @CallID", connection))
                {
                    cmd.Parameters.AddWithValue("@CallID", callId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new CallLog
                            {
                                CallID = (int)reader["CallID"],
                                ClientID = (int)reader["ClientID"],
                                AgentID = (string)reader["AgentID"],
                                StartTime = (DateTimeOffset)reader["StartTime"],
                                EndTime = (DateTimeOffset)reader["EndTime"]
                            };
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching CallLog: {ex.Message}");
        }
        return null;
    }

    public void AddCallLog(CallLog callLog)
    {
        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("INSERT INTO CallLogs (ClientID, AgentID, StartTime, EndTime) VALUES (@ClientID, @AgentID, @StartTime, @EndTime)", connection))
                {
                    cmd.Parameters.AddWithValue("@ClientID", callLog.ClientID);
                    cmd.Parameters.AddWithValue("@AgentID", callLog.AgentID);
                    cmd.Parameters.AddWithValue("@StartTime", callLog.StartTime);
                    cmd.Parameters.AddWithValue("@EndTime", callLog.EndTime);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding CallLog: {ex.Message}");
        }
    }

    public List<CallLog> GetAllCallLogs()
    {
        List<CallLog> callLogs = new List<CallLog>();

        try
        {
            using (var connection = _dbConnection.GetConnection())
            {
                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM CallLogs", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            callLogs.Add(new CallLog
                            {
                                CallID = (int)reader["CallID"],
                                ClientID = (int)reader["ClientID"],
                                AgentID = (string)reader["AgentID"],
                                StartTime = (DateTimeOffset)reader["StartTime"],
                                EndTime = (DateTimeOffset)reader["EndTime"]
                            });
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching CallLogs: {ex.Message}");
        }

        return callLogs;
    }
}
