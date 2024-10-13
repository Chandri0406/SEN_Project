using System;
using System.Collections.Generic;

namespace ApexCareSolutions.Models
{
    public class Technician
    {
        // Fields
        public string TechnicianID { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Technician()
        {

        }

        // Constructor
        public Technician(string technicianID, string username, string firstname, string lastname, string phone, string email)
        {
            TechnicianID = technicianID;
            Username = username;
            FirstName = firstname;
            LastName = lastname;
            Phone = phone;
            Email = email;
        }
    }
}
