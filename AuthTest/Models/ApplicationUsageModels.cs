using System;
using System.Data.Entity;

namespace AuthTest.Models
{
    public class ApplicationUsage
    {
        public ApplicationUsage()
        {
        }

        public int ApplicationUsageID { get; set; }
        public DateTime InvocationTime { get; set; }

        public int TrackedApplicationID { get; set; }

        public TrackedApplication TrackedApplication { get; set; }
    }

    public class ApplicationUsageData
    {
        public ApplicationUsageData()
        {
        }

        public int TrackedApplicationID { get; set; }
        public int ApplicationUsageCounter { get; set; }
    }
}