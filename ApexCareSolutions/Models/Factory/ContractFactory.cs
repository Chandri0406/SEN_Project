using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models.Factory
{
    public class ContractFactory
    {
        public IContract CreateContract(string type)
        {
            switch (type.toLowerInvariant())
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
    }
}