using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BugCapture.Domain.DataConnections;

namespace BugCapture.MVC.Controllers
{
    public class ApplicationsController : Controller
    {
        private ICT_Bug_CaptureEntities db = new ICT_Bug_CaptureEntities();

        //
        // GET: /Applications/

        public ActionResult Index()
        {
            return View(db.Applications.ToList());
        }

        //
        // GET: /Applications/Details/5

        public ActionResult Details(int id = 0)
        {
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        //
        // GET: /Applications/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Applications/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Application application)
        {
            if (ModelState.IsValid)
            {
                db.Applications.Add(application);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(application);
        }

        //
        // GET: /Applications/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        //
        // POST: /Applications/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Application application)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application);
        }

        //
        // GET: /Applications/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        //
        // POST: /Applications/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}