using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Controllers
{
    public class UserController
    {
        private List<User> users = new List<User>();

        // Method to register a new user
        public void RegisterUser(string username, string password, string role)
        {
            User newUser = new User(username, password, role);
            users.Add(newUser);
            Console.WriteLine("User registered successfully.");
        }

        // Method to login a user
        public bool Login(string username, string password)
        {
            foreach (User user in users)
            {
                if (user.AuthenticateUser(username, password))
                {
                    Console.WriteLine("Login successful.");
                    return true;
                }
            }
            Console.WriteLine("Login failed.");
            return false;
        }

        // Method to edit user information
        public void EditUser(string username, string newPassword, string newRole)
        {
            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    user.UpdateUser(username, newPassword, newRole);
                    Console.WriteLine("User updated successfully.");
                }
            }
        }

        // Method to delete a user
        public void DeleteUser(string username)
        {
            users.RemoveAll(u => u.Username == username);
            Console.WriteLine("User deleted successfully.");
        }

        // Private method to validate password
        private bool ValidatePassword(string password)
        {
            // Simple validation for demonstration purposes
            return password.Length >= 6;
        }
    }
}