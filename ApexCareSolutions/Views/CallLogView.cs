using System;
using ApexCareSolutions.Models;

namespace ApexCareSolutions.Views
{
    public class CallLogView
    {
        private readonly ICallLogRepository _callLogRepository;

        public CallLogView(ICallLogRepository callLogRepository)
        {
            _callLogRepository = callLogRepository;
        }

        // View call logs for a specific client
        public void ViewCallLogsByClient(int clientId)
        {
            var callLogs = _callLogRepository.GetCallLogsByClientId(clientId);
            Console.WriteLine($"Call Logs for Client ID: {clientId}:");
            foreach (var log in callLogs)
            {
                Console.WriteLine($"Call ID: {log.CallID}, Start Time: {log.StartTime}, End Time: {log.EndTime}, Agent: {log.AgentID}");
            }
        }

        // Log a new call
        public void LogNewCall(CallLog callLog)
        {
            _callLogRepository.AddCallLog(callLog);
            Console.WriteLine($"Call logged with Call ID: {callLog.CallID} for Client ID: {callLog.ClientID}");
        }

        // Update call log
        public void UpdateCallLog(CallLog callLog)
        {
            _callLogRepository.UpdateCallLog(callLog);
            Console.WriteLine($"Call Log ID: {callLog.CallID} has been updated.");
        }

        // View specific call log by ID
        public void ViewCallLogById(int callId)
        {
            var log = _callLogRepository.GetCallLogById(callId);
            if (log != null)
            {
                Console.WriteLine($"Call ID: {log.CallID}, Client ID: {log.ClientID}, Start Time: {log.StartTime}, End Time: {log.EndTime}");
            }
            else
            {
                Console.WriteLine("Call log not found!");
            }
        }
    }
}
