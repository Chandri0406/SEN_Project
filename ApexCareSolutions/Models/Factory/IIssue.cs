using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexCareSolutions.Models.Factory
{
    public interface IIssue
    {
        int IssueID { get; }
        int ClientID { get; }
        int CallID { get; }
        string Priority { get; }
        string Status { get; }
        DateTime StartDate { get; }
        DateTime EndDate { get; }
    }
}
