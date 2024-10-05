using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public abstract class Notifications
    {

        public Notifications()
        {
            
        }

        private int notificationID
        private string message
        private DateTime dateSent
        private string recipient
        private bool isRead


        //Encapsualted fields:
        public global::System.Int32 NotificationID { get => notificationID; set => notificationID = value; }
        public global::System.String Message { get => message; set => message = value; }
        public DateTime DateSent { get => dateSent; set => dateSent = value; }
        public global::System.String Recipient { get => recipient; set => recipient = value; }
        public global::System.Boolean IsRead { get => isRead; set => isRead = value; }

        // Constructor
        public Notification(int id, string message, DateTime dateSent, string recipient)
        {
            NotificationID = id;
            Message = message;
            DateSent = dateSent;
            Recipient = recipient;
            IsRead = false;
        }

        // Method to mark notification as read
        public void MarkAsRead()
        {
            IsRead = true;
        }
    }

    // Child Class: Contract Renewal
    public class ContractRenewal : Notification
    {
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
        public abstract void SendRenewalNotification();
    }
}