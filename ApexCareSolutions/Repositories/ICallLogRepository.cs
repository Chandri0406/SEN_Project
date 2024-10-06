using ApexCareSolutions.Models;
using System.Collections.Generic;

namespace ApexCareSolutions.Repositories
{
    public interface ICallLogRepository
    {
        IEnumerable<CallLog> GetAllCallLogs();
        CallLog GetCallLogById(int id);
        void AddCallLog(CallLog callLog);
        void UpdateCallLog(CallLog callLog);
        void DeleteCallLog(int id);
    }
}
