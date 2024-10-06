using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexCareSolutions.Models.Factory
{
    public interface IContract
    {
        int ContractID { get; }
        int ClientID { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        string Status { get; }
    }
}
