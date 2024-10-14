using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Npgsql;

namespace ApexCareSolutions.Models
{
    public class DBConnection
    {
        private readonly string _connectionString;
        private ContractFactory contractFactory;
        private IssueFactory issueFactory;

        public DBConnection()
        {
            _connectionString = $"Host=localhost;Database=ApexCare_DB;Username=Tester;Password=5432;";
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        //Using Stored Procedure for Getting Technicians
        public List<profileTechnicianModel> GetTechnicians()
        {
            var technicians = new List<profileTechnicianModel>();

            using (var conn = GetConnection()) 
            {
                conn.Open();

                //Calling the Procedure
                using (var command = new NpgsqlCommand("sp_gettchniciandetails(IN p_technicianid text)", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    //Executing Stored Procedure
                    using (var reader = command.ExecuteReader()) 
                    { 
                        while (reader.Read())
                        {
                            var technician = new profileTechnicianModel
                            {
                                TechnicianID = reader.GetString(0),
                                Username = reader.GetString(1),
                                FirstName = reader.GetString(2),
                                LastName = reader.GetString(3),
                                Phone = reader.IsDBNull(4) ? null : reader.GetString(3), //Handles NULL VALUES
                                Email = reader.IsDBNull(5) ? null : reader.GetString(4),
                            };
                            technicians.Add(technician);
                        }
                    }
                }
            }
            return technicians;
        }
    }
}
