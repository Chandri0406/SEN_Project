using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;
using System.Data;
using static System.Net.Mime.MediaTypeNames;

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

        //Using Stored Procedure for Getting Technicians
        public Technician GetTechnicians(string TechnicianID)
        {
            Technician technician = null;

            using (var conn = GetConnection()) 
            {
                conn.Open();

                //Calling the Procedure
                using (var command = new NpgsqlCommand("sp_gettchniciandetails", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("p_technicianid", TechnicianID);

                    //Executing Stored Procedure
                    using (var reader = command.ExecuteReader()) 
                    { 
                        while (reader.Read())
                        {
                            technician = new Technician
                            {
                                TechnicianID = reader.GetString(0),
                                Username = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                LastName = reader.GetString(3),
                                Phone = reader.IsDBNull(4) ? null : reader.GetString(3), //Handles NULL VALUES
                                Email = reader.IsDBNull(5) ? null : reader.GetString(4),
                            };
                        }
                    }
                }
            }
            return technician;
        }
    }
}
