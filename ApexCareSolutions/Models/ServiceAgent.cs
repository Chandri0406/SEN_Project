using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class ServiceAgent
    {
        // UML ServiceAgentModel
        // AgentID, Username, FirstName, LastName, Phone, Email
        public int AgentID { get; set; }// int or string
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        // Constructor
        public ServiceAgent() { }

        // Constructor with parameters
        public ServiceAgent(int agentID, string username, string firstName, string lastName, string phone, string email)
        {
            AgentID = agentID;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
        }
    }
}
