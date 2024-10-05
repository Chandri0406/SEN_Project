using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class MeterMalfunction : Notifications
    {
        public MeterMalfunction() : base
        {
            
        }

        public string MeterID { get; set; }           // The identifier for the meter
        public string IssueDescription { get; set; }  // Description of the malfunction or issue
        public DateTime ReportedDate { get; set; }    // Date when the malfunction was detected/reported

        // Constructor
        public MeterMalfunctionNotification(int id, string message, DateTime dateSent, string recipient, string meterID, string issueDescription, DateTime reportedDate)
            : base(id, message, dateSent, recipient)
        {
            MeterID = meterID;
            IssueDescription = issueDescription;
            ReportedDate = reportedDate;
        }

        // Method to send malfunction notification
        public override void SendMalfunctionAlert()
        {
            // Logic to send the malfunction alert to the user
            Console.WriteLine($"Meter {MeterID} has reported an issue: {IssueDescription} on {ReportedDate}. Please contact support for assistance.");
        }
    }
}