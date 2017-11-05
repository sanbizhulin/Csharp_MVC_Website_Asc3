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
    public class ContributionController : Controller
    {
        private Dbtest db = new Dbtest();

        //
        // GET: /Contribution/

        public ActionResult Index()
        {

            var con0 = from c in db.ContributionTypeTable where c.ContributionTypeID == 1 select c;

            if (con0.Count() == 0)
            {
                ContributionType con1 = new ContributionType();
                con1.ContributionTypeID = 1;
                con1.ContributionTypeName = "Money";
                ContributionType con2 = new ContributionType();
                con2.ContributionTypeID = 2;
                con2.ContributionTypeName = "Food";
                ContributionType con3 = new ContributionType();
                con3.ContributionTypeID = 3;
                con3.ContributionTypeName = "Beverage";
                ContributionType con4 = new ContributionType();
                con4.ContributionTypeID = 4;
                con4.ContributionTypeName = "Else";
                
                db.ContributionTypeTable.Add(con1);
                db.ContributionTypeTable.Add(con2);
                db.ContributionTypeTable.Add(con3);
                db.ContributionTypeTable.Add(con4);
              
                db.SaveChanges();
            }

            var contributiontable = db.ContributionTable.Include(c => c.contributiontype);
            return View(contributiontable.ToList());
        }

        //
        // GET: /Contribution/Details/5

        public ActionResult Details(int id = 0)
        {
            Contribution contribution = db.ContributionTable.Find(id);
            if (contribution == null)
            {
                return HttpNotFound();
            }
            return View(contribution);
        }

        //
        // GET: /Contribution/Create

        public ActionResult Create()
        {
            ViewBag.ContributionTypeID = new SelectList(db.ContributionTypeTable, "ContributionTypeID", "ContributionTypeName");
            return View();
        }

        //
        // POST: /Contribution/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Contribution contribution)
        {
            if (ModelState.IsValid)
            {
                db.ContributionTable.Add(contribution);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContributionTypeID = new SelectList(db.ContributionTypeTable, "ContributionTypeID", "ContributionTypeName", contribution.ContributionTypeID);
            return View(contribution);
        }

        //
        // GET: /Contribution/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Contribution contribution = db.ContributionTable.Find(id);
            if (contribution == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContributionTypeID = new SelectList(db.ContributionTypeTable, "ContributionTypeID", "ContributionTypeName", contribution.ContributionTypeID);
            return View(contribution);
        }

        //
        // POST: /Contribution/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Contribution contribution)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contribution).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContributionTypeID = new SelectList(db.ContributionTypeTable, "ContributionTypeID", "ContributionTypeName", contribution.ContributionTypeID);
            return View(contribution);
        }

        //
        // GET: /Contribution/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Contribution contribution = db.ContributionTable.Find(id);
            if (contribution == null)
            {
                return HttpNotFound();
            }
            return View(contribution);
        }

        //
        // POST: /Contribution/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contribution contribution = db.ContributionTable.Find(id);
            db.ContributionTable.Remove(contribution);
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