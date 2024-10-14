using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class Complaint
    {
        public int ComplaintID { get; set; }
        public int ClientID { get; set; }
        public string IssueID { get; set; }
        public DateTime DateReported { get; set; }
        public DateTime? DateResolved { get; set; } // Nullable if not yet resolved
        public string Description { get; set; }

        // Constructor
        public Complaint(int clientID, string issueID, string description, DateTime dateReported, DateTime dateResolved)
        {
            ClientID = clientID;
            IssueID = issueID;
            Description = description;
            DateReported = dateReported;
            DateResolved = dateResolved;
        }

        public Complaint()
        {
            
        }

        // Optional: Validation logic
        public bool IsResolved()
        {
            return DateResolved.HasValue;
        }

        public override string ToString()
        {
            return $"{ClientID}; {IssueID}; {Description}; {DateReported}; {DateResolved}";
        }


    }
}