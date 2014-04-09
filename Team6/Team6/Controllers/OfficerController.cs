using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Team6.Models;
using Team6.DAL;

namespace Team6.Controllers
{
    public class OfficerController : Controller
    {
        private Team6Context db = new Team6Context();

        // GET: /Officer/
        public ActionResult Index()
        {
            return View(db.Officers.ToList());
        }

        // GET: /Officer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Officer officer = db.Officers.Find(id);
            if (officer == null)
            {
                return HttpNotFound();
            }
            return View(officer);
        }

        // GET: /Officer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Officer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="officerID,badge_number,rank,first_name,last_name,user_name,paswerd,phone_number,email,ssn,eye_color,feet,inches,gender")] Officer officer)
        {
            if (ModelState.IsValid)
            {
                db.Officers.Add(officer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(officer);
        }

        // GET: /Officer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Officer officer = db.Officers.Find(id);
            if (officer == null)
            {
                return HttpNotFound();
            }
            return View(officer);
        }

        // POST: /Officer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="officerID,badge_number,rank,first_name,last_name,user_name,paswerd,phone_number,email,ssn,eye_color,feet,inches,gender")] Officer officer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(officer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(officer);
        }

        // GET: /Officer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Officer officer = db.Officers.Find(id);
            if (officer == null)
            {
                return HttpNotFound();
            }
            return View(officer);
        }

        // POST: /Officer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Officer officer = db.Officers.Find(id);
            db.Officers.Remove(officer);
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
