using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class InstallationIssue : IIssue
    {
        public int IssueID { get; set; }
        public int ClientID { get; set; }
        public int CallID { get; set; }
        public string Priority { get; set; }
        public string Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string Description { get; set; }

        public InstallationIssue(int clientID, int callID, string priority, string status, DateTime startDate, DateTime endDate)
        {
            ClientID = clientID;
            CallID = callID;
            Priority = priority;
            Status = status;
            StartDate = startDate;
            EndDate = endDate;
            Description = "Installation Issue";
        }

        public InstallationIssue()
        {
            Description = "Installation Issue";
        }
    }
}