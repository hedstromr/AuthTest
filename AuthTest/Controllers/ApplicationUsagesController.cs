using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AuthTest.Models;

namespace AuthTest.Controllers
{
    public class ApplicationUsagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ApplicationUsages/1
        public ActionResult Index(int id)
        {
            var applicationUsages = db.ApplicationUsages.Include(a => a.TrackedApplication).Where(b => b.TrackedApplicationID == id);
            return View(applicationUsages.ToList());
        }

        // GET: ApplicationUsages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUsage applicationUsage = db.ApplicationUsages.Find(id);
            if (applicationUsage == null)
            {
                return HttpNotFound();
            }
            return View(applicationUsage);
        }

        // GET: ApplicationUsages/Create
        public ActionResult Create()
        {
            ViewBag.TrackedApplicationID = new SelectList(db.TrackedApplications, "TrackedApplicationID", "TrackedApplicationName");
            return View();
        }

        // POST: ApplicationUsages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationUsageID,InvocationTime,TrackedApplicationID")] ApplicationUsage applicationUsage)
        {
            if (ModelState.IsValid)
            {
                db.ApplicationUsages.Add(applicationUsage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TrackedApplicationID = new SelectList(db.TrackedApplications, "TrackedApplicationID", "TrackedApplicationName", applicationUsage.TrackedApplicationID);
            return View(applicationUsage);
        }

        // GET: ApplicationUsages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUsage applicationUsage = db.ApplicationUsages.Find(id);
            if (applicationUsage == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrackedApplicationID = new SelectList(db.TrackedApplications, "TrackedApplicationID", "TrackedApplicationName", applicationUsage.TrackedApplicationID);
            return View(applicationUsage);
        }

        // POST: ApplicationUsages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationUsageID,InvocationTime,TrackedApplicationID")] ApplicationUsage applicationUsage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicationUsage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TrackedApplicationID = new SelectList(db.TrackedApplications, "TrackedApplicationID", "TrackedApplicationName", applicationUsage.TrackedApplicationID);
            return View(applicationUsage);
        }

        // GET: ApplicationUsages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUsage applicationUsage = db.ApplicationUsages.Find(id);
            if (applicationUsage == null)
            {
                return HttpNotFound();
            }
            return View(applicationUsage);
        }

        // POST: ApplicationUsages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicationUsage applicationUsage = db.ApplicationUsages.Find(id);
            db.ApplicationUsages.Remove(applicationUsage);
            db.SaveChanges();
            return RedirectToAction("Index");
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
