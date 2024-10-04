using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class ServiceAgent : CallLog
    {
        //UML ServiceAgentModel
        //AgentID, Username, FirstName, LastName, Phone, Email
        public int AgentID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }


        public ServiceAgent()
        {
            
        }
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