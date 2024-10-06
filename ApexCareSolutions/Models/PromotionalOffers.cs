using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class PromotionalOffers : Notifications
    {

        public PromotionalOffers() : base()
        {
            
        }

        public int OfferID { get; set; }
        public string OfferDetails { get; set; }
        public DateTime ExpiryDate { get; set; }
        public double DiscountRate { get; set; }

        // Constructor
        public PromotionalOffers(int id, string message, DateTime dateSent, string recipient, int offerID, string offerDetails, DateTime expiryDate, double discountRate)
            : base(id, message, dateSent, recipient)
        {
            OfferID = offerID;
            OfferDetails = offerDetails;
            ExpiryDate = expiryDate;
            DiscountRate = discountRate;
        }

        // Method to send promotional offer
        public override void SendOfferNotification()
        {
            // Logic for sending offer notification
            Console.WriteLine($"Special offer {OfferID}: {OfferDetails}. Expiry: {ExpiryDate}. Discount: {DiscountRate}%");
        }
    }
}