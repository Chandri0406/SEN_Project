using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        [Required]
        public int ClientID { get; set; }
        [Required]
        public string IssueID { get; set; }
        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5.")]
        public int Rating { get; set; }
        public string Comments { get; set; }
        [Required]
        public DateTime DateProvided { get; set; }

        // Constructor
        public Feedback(int clientID, string issueID, int rating, string comments, DateTime dateProvided)
        {
            ClientID = clientID;
            IssueID = issueID;
            Rating = rating;
            Comments = comments;
            DateProvided = dateProvided;
        }

        public Feedback()
        {
            
        }

        // Optional: Validation logic or methods related to feedback
        public bool IsValid()
        {
            return Rating >= 1 && Rating <= 5; // For example, ensure rating is between 1 and 5
        }
    }
}