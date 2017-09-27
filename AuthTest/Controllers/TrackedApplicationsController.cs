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
    public class TrackedApplicationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TrackedApplications
        public ActionResult Index()
        {
            return View(db.TrackedApplications.ToList());
        }

        // GET: TrackedApplications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackedApplication trackedApplication = db.TrackedApplications.Find(id);
            if (trackedApplication == null)
            {
                return HttpNotFound();
            }
            return View(trackedApplication);
        }

        // GET: TrackedApplications/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TrackedApplications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrackedApplicationID,TrackedApplicationName")] TrackedApplication trackedApplication)
        {
            if (ModelState.IsValid)
            {
                db.TrackedApplications.Add(trackedApplication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(trackedApplication);
        }

        // GET: TrackedApplications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackedApplication trackedApplication = db.TrackedApplications.Find(id);
            if (trackedApplication == null)
            {
                return HttpNotFound();
            }
            return View(trackedApplication);
        }

        // POST: TrackedApplications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrackedApplicationID,TrackedApplicationName")] TrackedApplication trackedApplication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trackedApplication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(trackedApplication);
        }

        // GET: TrackedApplications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrackedApplication trackedApplication = db.TrackedApplications.Find(id);
            if (trackedApplication == null)
            {
                return HttpNotFound();
            }
            return View(trackedApplication);
        }

        // POST: TrackedApplications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrackedApplication trackedApplication = db.TrackedApplications.Find(id);
            db.TrackedApplications.Remove(trackedApplication);
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
