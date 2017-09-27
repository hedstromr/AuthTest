using System.Web.Http;
using System.Web.Http.Description;
using AuthTest.Models;

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