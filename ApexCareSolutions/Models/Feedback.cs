using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public int ClientID { get; set; }
        public int IssueID { get; set; }
        public int Rating { get; set; }
        public string Comments { get; set; }
        public DateTime DateProvided { get; set; }

        // Constructor
        public Feedback(int clientID, int issueID, int rating, string comments, DateTime dateProvided)
        {
            ClientID = clientID;
            IssueID = issueID;
            Rating = rating;
            Comments = comments;
            DateProvided = dateProvided;
        }

        // Optional: Validation logic or methods related to feedback
        public bool IsValid()
        {
            return Rating >= 1 && Rating <= 5; // For example, ensure rating is between 1 and 5
        }
    }
}