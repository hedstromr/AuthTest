using System.Data.Entity;

namespace AuthTest.Models
{
    public class TrackedApplication
    {
        public TrackedApplication()
        {
        }

        public int TrackedApplicationID { get; set; }
        public string TrackedApplicationName { get; set; }
    }
}
