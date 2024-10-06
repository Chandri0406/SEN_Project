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
        public int IssueID { get; set; }
        public DateTime DateReported { get; set; }
        public DateTime? DateResolved { get; set; } // Nullable if not yet resolved
        public string Description { get; set; }

        // Constructor
        public Complaint(int clientID, int issueID, string description, DateTime dateReported)
        {
            ClientID = clientID;
            IssueID = issueID;
            Description = description;
            DateReported = dateReported;
        }

        // Optional: Validation logic
        public bool IsResolved()
        {
            return DateResolved.HasValue;
        }
    }
}