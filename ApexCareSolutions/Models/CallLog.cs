using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models
{
    public class CallLog : Clients
    {
        //UML Calllog Model 
        // CallID,ClientID,AgentID,StartTime,EndTime
        public int CallID { get; set; }
        public int ClientID { get; set; }
        public int AgentID { get; set; }
        public DateTimeOffset StartTime { get; set; } 
        public DateTimeOffset EndTime { get; set; }

        public CallLog()
        {

        }
        public CallLog(int callID, int clientID, int agentID, DateTimeOffset startTime, DateTimeOffset endTime)
        {
            CallID = callID;
            ClientID = clientID;
            AgentID = agentID;
            StartTime = startTime;
            EndTime = endTime;
        }



    }
}