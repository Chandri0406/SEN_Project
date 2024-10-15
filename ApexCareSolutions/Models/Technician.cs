using System;
using System.Collections.Generic;
using System.Numerics;

namespace ApexCareSolutions.Models
{
    public class Technician
    {
        // Properties
        public int TechnicianID {get ; set;}

        public string Username{get ; set;}

        public string FirstName { get; set; }

        public string LastName { get; set; }
        

        public string Phone { get; set; }


        public string Email { get; set; }

        // Constructor
        public Technician(int technicianID, string username, string firstName, string lastName, string phone, string email)
        {
            TechnicianID = technicianID;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }

        

        public void ViewIssue(IIssue issue)
        {
            Console.WriteLine($"Handling issue ID: {issue.IssueID}, Priority: {issue.Priority}");
        }
    }
}