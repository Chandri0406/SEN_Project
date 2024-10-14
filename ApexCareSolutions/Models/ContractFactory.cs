using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class ContractFactory
    {
        public IContract CreateContract(string type)
        {
            switch (type.ToLower())
            {
                case "commercial":
                    return new CommercialContract();
                    break;
                case "private":
                    return new PrivateContract();
                    break;
                case "warranty":
                    return new WarrantyContract();
                    break;
                default:
                    return null;
            }
        }

        public string DetermineType(IContract c)
        {
            if (c is CommercialContract ct1)
            {
                return ct1.Type;
            }
            else if (c is PrivateContract ct2)
            {
                return ct2.Type;
            }
            else if (c is WarrantyContract ct3)
            {
                return ct3.Type;
            }
            else
            {
                return null;
            }
        }

        public string DetermineResidency(IContract c)
        {
            if (c is CommercialContract ct1)
            {
                return ct1.Residency;
            }
            else if (c is PrivateContract ct2)
            {
                return ct2.Residency;
            }
            else if (c is WarrantyContract ct3)
            {
                return ct3.Residency;
            }
            else
            {
                return null;
            }
        }
    }
}