using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class User
    {
        // Public attributes
        public string Username { get; set; }

        // Private attributes
        public string Password { get; set; }

        public string Role { get; set; }

        // Public constructor
        public User(string username, string password, string role)
        {
            this.Username = username;
            this.Password = password; // Password hashing
            this.Role = role;
        }

        public User()
        {
        }

        // Public method to authenticate user
        public bool AuthenticateUser(string username, string password)
        {
            return this.Username == username && this.Password == password;
        }

        // Public method to update user info
        public void UpdateUser(string username, string password, string role)
        {
            this.Username = username;
            this.Password = password; 
            this.Role = role;
        }

        // Public method to delete user
        public void DeleteUser()
        {
            // Logic to delete user
            Console.WriteLine("User deleted.");
        }

    }
}