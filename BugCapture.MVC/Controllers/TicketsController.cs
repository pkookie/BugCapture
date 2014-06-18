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
    public class TicketsController : Controller
    {
        private ICT_Bug_CaptureEntities db = new ICT_Bug_CaptureEntities();

        //
        // GET: /Tickets/

        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.Priority);
            return View(tickets.ToList());
        }

        //
        // GET: /Tickets/Details/5

        public ActionResult Details(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // GET: /Tickets/Create

        public ActionResult Create()
        {
            ViewBag.PriorityId = new SelectList(db.Priorities, "PriorityId", "Name");
            return View();
        }

        //
        // POST: /Tickets/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PriorityId = new SelectList(db.Priorities, "PriorityId", "Name", ticket.PriorityId);
            return View(ticket);
        }

        //
        // GET: /Tickets/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.PriorityId = new SelectList(db.Priorities, "PriorityId", "Name", ticket.PriorityId);
            return View(ticket);
        }

        //
        // POST: /Tickets/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PriorityId = new SelectList(db.Priorities, "PriorityId", "Name", ticket.PriorityId);
            return View(ticket);
        }

        //
        // GET: /Tickets/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        //
        // POST: /Tickets/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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