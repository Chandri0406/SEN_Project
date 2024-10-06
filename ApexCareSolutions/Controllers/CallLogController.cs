using ApexCareSolutions.Models;
using ApexCareSolutions.Views;

namespace ApexCareSolutions.Controllers
{
    public class CallLogController
    {
        private readonly ICallLogRepository _callLogRepository;
        private readonly CallLogView _callLogView;

        public CallLogController(ICallLogRepository callLogRepository)
        {
            _callLogRepository = callLogRepository;
            _callLogView = new CallLogView(_callLogRepository); // Initialize the view with the repository
        }

        // Log a new call
        public void LogNewCall(CallLog callLog)
        {
            _callLogView.LogNewCall(callLog);
        }

        // Update an existing call log
        public void UpdateCallLog(CallLog callLog)
        {
            _callLogView.UpdateCallLog(callLog);
        }

        // View call logs for a specific client
        public void ViewCallLogsByClient(int clientId)
        {
            _callLogView.ViewCallLogsByClient(clientId);
        }

        // View a specific call log by its ID
        public void ViewCallLogById(int callId)
        {
            _callLogView.ViewCallLogById(callId);
        }
    }
}
