using System.Data.Entity;

namespace AuthTest.Models
{
    public class ApplicationUsage
    {
        public ApplicationUsage()
        {
        }

        public int ApplicationUsageID { get; set; }
        public int ApplicationID { get; set; }

        public int TrackedApplicationID { get; set; }

        public TrackedApplication TrackedApplication { get; set; }
    }
}