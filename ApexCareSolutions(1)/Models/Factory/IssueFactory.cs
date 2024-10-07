using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApexCareSolutions.Models.Factory
{
    public class IssueFactory
    {
        public IIssue CreateIssue(string type)
        {
            switch (type.ToLower())
            {
                case "power trip":
                    return new PowerTripIssue();
                    break;
                case "installation":
                    return new InstallationIssue();
                    break;
                case "malfunction":
                    return new MalfunctionIssue();
                    break;
                default:
                    return null;
            }
        }

        public string DetermineType(IIssue i)
        {
            if (i is PowerTripIssue it1)
            {
                return it1.Description;
            }
            else if (i is InstallationIssue it2)
            {
                return it2.Description;
            }
            else if (i is MalfunctionIssue it3)
            {
                return it3.Description;
            }
            else
            {
                return null;
            }
        }
    }
}