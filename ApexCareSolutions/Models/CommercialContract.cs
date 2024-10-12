using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class CommercialContract : IContract, IResidency
    {
        public int ContractID { get; set; }
        public int ClientID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }

        public string Type { get; set; }

        public string Residency { get; set; }

        public CommercialContract(int clientID, DateTime startDate, DateTime endDate, string status, string residency)
        {
            ClientID = clientID;
            StartDate = startDate;
            EndDate = endDate;
            Status = status;
            Type = "Commercial";
            Residency = residency;
        }

        public CommercialContract()
        {
            Type = "Commercial";
        }
    }
}