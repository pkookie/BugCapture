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
    public class DocumentsController : Controller
    {
        private ICT_Bug_CaptureEntities db = new ICT_Bug_CaptureEntities();

        //
        // GET: /Documents/

        public ActionResult Index()
        {
            var documents = db.Documents.Include(d => d.DocumentType);
            return View(documents.ToList());
        }

        //
        // GET: /Documents/Details/5

        public ActionResult Details(int id = 0)
        {
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        //
        // GET: /Documents/Create

        public ActionResult Create()
        {
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Name");
            return View();
        }

        //
        // POST: /Documents/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Document document)
        {
            if (ModelState.IsValid)
            {
                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Name", document.DocumentTypeId);
            return View(document);
        }

        //
        // GET: /Documents/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Name", document.DocumentTypeId);
            return View(document);
        }

        //
        // POST: /Documents/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DocumentTypeId = new SelectList(db.DocumentTypes, "DocumentTypeId", "Name", document.DocumentTypeId);
            return View(document);
        }

        //
        // GET: /Documents/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        //
        // POST: /Documents/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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