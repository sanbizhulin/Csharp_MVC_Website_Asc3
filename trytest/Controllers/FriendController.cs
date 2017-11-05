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
    public class FriendController : Controller
    {
        private Dbtest db = new Dbtest();

        //
        // GET: /Friend/

      
        public ActionResult Index()
        {
            return View(db.FriendTable.ToList());
        }
        public ActionResult Navigate()
        {
            return View();
        }

        //
        // GET: /Friend/Details/5

        public ActionResult Details(int id = 0)
        {
            Friend friend = db.FriendTable.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        //
        // GET: /Friend/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Friend/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.FriendTable.Add(friend);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(friend);
        }

        //
        // GET: /Friend/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Friend friend = db.FriendTable.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        //
        // POST: /Friend/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Friend friend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(friend).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(friend);
        }

        //
        // GET: /Friend/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Friend friend = db.FriendTable.Find(id);
            if (friend == null)
            {
                return HttpNotFound();
            }
            return View(friend);
        }

        //
        // POST: /Friend/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Friend friend = db.FriendTable.Find(id);
            db.FriendTable.Remove(friend);
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