using System.Collections.Generic;
using ApexCareSolutions.Models;

public interface ICallLogRepository
{
    CallLog GetCallLogById(int callId);
    void AddCallLog(CallLog callLog);
    List<CallLog> GetAllCallLogs();
}
