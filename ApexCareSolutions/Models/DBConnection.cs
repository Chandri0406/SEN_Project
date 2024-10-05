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

        public DatabaseConnection()
        {
            _connectionString = $"Host=localhost;Database=ApexCare_DB;Username=Tester;Password=5432;";
        }

        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

    }
}