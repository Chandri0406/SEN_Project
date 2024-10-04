using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models.Factory
{
    public class CommercialContract : IContract, IResidency
    {
        int ContractID { get; set; }
        int ClientID { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        string Status { get; set; }

        string Type { get; set; }

        string Residency { get; set; }

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