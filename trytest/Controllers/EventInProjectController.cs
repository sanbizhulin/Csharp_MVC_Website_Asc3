using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trytest.Models;

namespace trytest.Controllers
{
    public class EventInProjectController : Controller
    {
        private Dbtest db = new Dbtest();

        //
        // GET: /EventInProject/

        public ActionResult Index()
        {
            //EventInProjectType type = new EventInProjectType();
            //EventInProjectStatus eventrole0 = new EventInProjectStatus();
            var type = from t in db.EventInProjcetTypeTable where t.EventInProjectTypeID == 1 select t;

            var status = from s in db.EventInProjcetStatusTable where s.EventInProjectStatusID == 1 select s;

            if (status.Count() == 0)
            {
                EventInProjectStatus eventrole1 = new EventInProjectStatus();
                eventrole1.EventInProjectStatusID = 1;
                eventrole1.EventInProjectStatusName = "Open";
                EventInProjectStatus eventrole2 = new EventInProjectStatus();
                eventrole2.EventInProjectStatusID = 2;
                eventrole2.EventInProjectStatusName = "Pending";
                EventInProjectStatus eventrole3 = new EventInProjectStatus();
                eventrole3.EventInProjectStatusID = 3;
                eventrole3.EventInProjectStatusName = "Closed";
                EventInProjectStatus eventrole4 = new EventInProjectStatus();
                eventrole4.EventInProjectStatusID = 4;
                eventrole4.EventInProjectStatusName = "Lock";
                db.EventInProjcetStatusTable.Add(eventrole1);
                db.EventInProjcetStatusTable.Add(eventrole2);
                db.EventInProjcetStatusTable.Add(eventrole3);
                db.EventInProjcetStatusTable.Add(eventrole4);
                db.SaveChanges();
            }
            if (type.Count() == 0)
            {
                EventInProjectType type1 = new EventInProjectType();
                type1.EventInProjectTypeID = 1;
                type1.EventInProjectTypeName = "Breakfast";
                EventInProjectType type2 = new EventInProjectType();
                type2.EventInProjectTypeID = 2;
                type2.EventInProjectTypeName = "Lunch";
                EventInProjectType type3 = new EventInProjectType();
                type3.EventInProjectTypeID = 3;
                type3.EventInProjectTypeName = "Dinner";
                EventInProjectType type4 = new EventInProjectType();
                type4.EventInProjectTypeID = 4;
                type4.EventInProjectTypeName = "Party";
                EventInProjectType type5 = new EventInProjectType();
                type5.EventInProjectTypeID = 5;
                type5.EventInProjectTypeName = "Doing Sports";
                EventInProjectType type6 = new EventInProjectType();
                type6.EventInProjectTypeID = 6;
                type6.EventInProjectTypeName = "Play games";
                db.EventInProjcetTypeTable.Add(type1);
                db.EventInProjcetTypeTable.Add(type2);
                db.EventInProjcetTypeTable.Add(type3);
                db.EventInProjcetTypeTable.Add(type4);
                db.EventInProjcetTypeTable.Add(type5);
                db.EventInProjcetTypeTable.Add(type6);
                db.SaveChanges();
            }
            var eventinprojcettable = db.EventInProjcetTable.Include(e => e.friend).Include(e => e.eventinprojecttype).Include(e => e.eventinprojectstatus);
            return View(eventinprojcettable.ToList());
        }

        //
        // GET: /EventInProject/Details/5

        public ActionResult Details(int id = 0)
        {
            EventInProject eventinproject = db.EventInProjcetTable.Find(id);
            if (eventinproject == null)
            {
                return HttpNotFound();
            }
            return View(eventinproject);
        }

        //
        // GET: /EventInProject/Create

        public ActionResult Create()
        {
            
            ViewBag.FriendID = new SelectList(db.FriendTable, "FriendID", "FriendName");
            ViewBag.EventInProjectTypeID = new SelectList(db.EventInProjcetTypeTable, "EventInProjectTypeID", "EventInProjectTypeName");
            ViewBag.EventInProjectStatusID = new SelectList(db.EventInProjcetStatusTable, "EventInProjectStatusID", "EventInProjectStatusName");
            return View();
        }

        //
        // POST: /EventInProject/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EventInProject eventinproject)
        {


            if (ModelState.IsValid)
            {
                if( int.Parse(Session["UserRole"].ToString())==3)
                { eventinproject.EventInProjectStatusID = 2; }

                db.EventInProjcetTable.Add(eventinproject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FriendID = new SelectList(db.FriendTable, "FriendID", "FriendName", eventinproject.FriendID);
            ViewBag.EventInProjectTypeID = new SelectList(db.EventInProjcetTypeTable, "EventInProjectTypeID", "EventInProjectTypeName", eventinproject.EventInProjectTypeID);
            ViewBag.EventInProjectStatusID = new SelectList(db.EventInProjcetStatusTable, "EventInProjectStatusID", "EventInProjectStatusName", eventinproject.EventInProjectStatusID);
            return View(eventinproject);
        }

        //
        // GET: /EventInProject/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EventInProject eventinproject = db.EventInProjcetTable.Find(id);
            if (eventinproject == null)
            {
                return HttpNotFound();
            }
            ViewBag.FriendID = new SelectList(db.FriendTable, "FriendID", "FriendName", eventinproject.FriendID);
            ViewBag.EventInProjectTypeID = new SelectList(db.EventInProjcetTypeTable, "EventInProjectTypeID", "EventInProjectTypeName", eventinproject.EventInProjectTypeID);
            ViewBag.EventInProjectStatusID = new SelectList(db.EventInProjcetStatusTable, "EventInProjectStatusID", "EventInProjectStatusName", eventinproject.EventInProjectStatusID);
            return View(eventinproject);
        }

        //
        // POST: /EventInProject/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EventInProject eventinproject)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventinproject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FriendID = new SelectList(db.FriendTable, "FriendID", "FriendName", eventinproject.FriendID);
            ViewBag.EventInProjectTypeID = new SelectList(db.EventInProjcetTypeTable, "EventInProjectTypeID", "EventInProjectTypeName", eventinproject.EventInProjectTypeID);
            ViewBag.EventInProjectStatusID = new SelectList(db.EventInProjcetStatusTable, "EventInProjectStatusID", "EventInProjectStatusName", eventinproject.EventInProjectStatusID);
            return View(eventinproject);
        }

        //
        // GET: /EventInProject/Delete/5

        public ActionResult Delete(int id = 0)
        {
            EventInProject eventinproject = db.EventInProjcetTable.Find(id);
            if (eventinproject == null)
            {
                return HttpNotFound();
            }
            return View(eventinproject);
        }

        //
        // POST: /EventInProject/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventInProject eventinproject = db.EventInProjcetTable.Find(id);
            db.EventInProjcetTable.Remove(eventinproject);
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