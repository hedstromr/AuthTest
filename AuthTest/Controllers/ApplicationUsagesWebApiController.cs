using System.Web.Http;
using System.Web.Http.Description;
using AuthTest.Models;
using System.Diagnostics;
using System;
using System.Globalization;
using System.Linq;

namespace AuthTest.Controllers
{
    public class ApplicationUsagesWebApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // POST: api/ApplicationUsagesWebApi
        // Weird, have to do: http://localhost:43810/api/ApplicationUsagesWebApi/CreateApplicationUsage/1
        // {"ApplicationUsageID":0,"InvocationTime":"2017-09-27T10:54:01","TrackedApplicationID":1,"TrackedApplication":null}
        [ResponseType(typeof(ApplicationUsage))]
        public IHttpActionResult CreateApplicationUsage([FromBody] ApplicationUsage applicationUsage)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            applicationUsage.ApplicationUsageID = 0;
            db.ApplicationUsages.Add(applicationUsage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = applicationUsage.ApplicationUsageID }, applicationUsage);
        }

        [ResponseType(typeof(ApplicationUsageData))]
        public IHttpActionResult GetApplicationUsage(int id)
        {
            db.Database.Log = s => {
                Debug.Print(s);
            };
            ApplicationUsageData result = new ApplicationUsageData();
            result.TrackedApplicationID = id;
            result.ApplicationUsageCounter = db.ApplicationUsages.Count(m => m.TrackedApplicationID == id);

            string timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture);
            Trace.WriteLine($"{timestamp} GetApplicationUsage id = {id} counter = {result.ApplicationUsageCounter}");

            return CreatedAtRoute("DefaultApi", new { id = id }, result);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}