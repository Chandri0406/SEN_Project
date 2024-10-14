using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class PrivateContract : IContract, IResidency
    {
        public string ContractID { get; set; }
        public int ClientID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        public string Type { get; set; }

        public string Residency { get; set; }

        public PrivateContract(int clientID, DateTime startDate, DateTime endDate, string status, string residency)
        {
            ClientID = clientID;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            Type = "Private";
            Residency = residency;
        }

        public PrivateContract()
        {
            Type = "Private";
        }
    }
}