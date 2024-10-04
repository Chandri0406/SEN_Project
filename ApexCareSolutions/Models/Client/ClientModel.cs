using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models.Clients
{
    public class ClientModel
    {
        // UML Client Model 
        //ClientID, Username, FirstName, LastName, Address, Phone, Email
        public int ClientID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    


        public ClientModel()
        {
            

        }
        public ClientsModel(int clientID, string username, string firstName, string lastName, string address, string phone, string email)
        {
            ClientID = clientID;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Phone = phone;
            Email = email;
        }

    }
}