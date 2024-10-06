using System;

namespace ApexCareSolutions.Models
{
    public class CallLog
    {
        // CallLog Model Fields
        public int CallID { get; set; }       // Unique identifier for each call log
        public int ClientID { get; set; }     // Foreign key to the client
        public string AgentID { get; set; }   // ID or reference to the agent handling the call, int or string
        public DateTimeOffset StartTime { get; set; }   // Call start time
        public DateTimeOffset EndTime { get; set; }     // Call end time
            // Navigation property to reference the associated ServiceAgent
        public ServiceAgent ServiceAgent { get; set; }
        //If it's possible that a CallLog might not always have a ServiceAgent or
        //Client assigned immediately, you might consider making the navigation properties nullable:
        //public ServiceAgent? ServiceAgent { get; set; }
        //public Clients? Client { get; set; }


        // Navigation property to reference the associated Client
        public Clients Client { get; set; }
        // Parameterless constructor
        public CallLog()
        {
        }

        // Constructor with parameters
        public CallLog(int callID, int clientID, string agentID, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            CallID = callID;
            ClientID = clientID;
            AgentID = agentID;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
