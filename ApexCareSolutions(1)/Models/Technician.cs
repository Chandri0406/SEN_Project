using System;
using System.Collections.Generic;
using ApexCareSolutions.Models.Factory;

namespace ApexCareSolutions.Models
{
    public class Technician
    {
        // Fields
        private int TechnicianID;
        private string Username;
        private string FirstName;
        private string LastName;
        private string Phone;
        private string Email;

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

        // Properties
        public int TechnicianID
        {
            get { return technicianID; }
            set { technicianID = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public void ViewIssue(IIssue issue)
        {
            Console.WriteLine($"Handling issue ID: {issue.IssueID}, Priority: {issue.Priority}");
        }
    }
}