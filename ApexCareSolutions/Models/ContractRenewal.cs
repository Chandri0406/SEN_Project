using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class ContractRenewal : Notifications
    {

        public ContractRenewal() : base()
        {
            
        }

        public int ContractID { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string RenewalOptions { get; set; }

        // Constructor
        public ContractRenewal(int id, string message, DateTime dateSent, string recipient, int contractID, DateTime expirationDate, string renewalOptions)
            : base(id, message, dateSent, recipient)
        {
            ContractID = contractID;
            ExpirationDate = expirationDate;
            RenewalOptions = renewalOptions;
        }

        // Method to send renewal notification
        public override void SendRenewalNotification()
        {
            // Logic for sending notification
            Console.WriteLine($"Contract {ContractID} is expiring on {ExpirationDate}. Options: {RenewalOptions}");
        }
    }
}