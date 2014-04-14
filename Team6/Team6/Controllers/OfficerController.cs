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
        public ActionResult Create([Bind(Include="OfficerID,BadgeNumber,Rank,FirstName,LastName,UserName,Password,PhoneNumber,Email,Ssn,EyeColor,Height,Gender")] Officer officer)
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
        public ActionResult Edit([Bind(Include="OfficerID,BadgeNumber,Rank,FirstName,LastName,UserName,Password,PhoneNumber,Email,Ssn,EyeColor,Height,Gender")] Officer officer)
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

        public ActionResult SearchOfficer (string firstName, string lastName, string userName, string email, string phoneNumber, string ssn, string badgeNumber)
        {
            var context = new Team6Context();
            string sqlQuery = "SELECT * FROM dbo.Officer";
            bool cont = false;

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phoneNumber) && string.IsNullOrEmpty(ssn) && string.IsNullOrEmpty(badgeNumber))
            {
                // some error message that the user should enter at least one field
            }
            else
            {
                sqlQuery = "SELECT * FROM dbo.Officer WHERE ";
                
                if (!string.IsNullOrEmpty(firstName))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "FirstName = \'" + firstName + "\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(lastName))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "LastName = \'" + lastName + "\'";
                    cont = true;
                }
            }

            var officers1 = context.Officers.SqlQuery(sqlQuery);
            return View(officers1.ToList());
        }
    }
}
