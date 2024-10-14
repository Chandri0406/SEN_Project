using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexCareSolutions.Models
{
    public interface IContract
    {
        string ContractID { get; }
        int ClientID { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
        string Status { get; }

    }
    // IEnumerable<IContract> GetContractsByClientId(int clientId);
    //IEnumerable<IContract> GetOngoingContractsByClientId(int clientId);
}
