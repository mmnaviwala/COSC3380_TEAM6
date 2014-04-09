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
    public class CriminalController : Controller
    {
        private Team6Context db = new Team6Context();

        // GET: /Criminal/
        public ActionResult Index()
        {
            return View(db.Criminals.ToList());
        }

        // GET: /Criminal/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criminal criminal = db.Criminals.Find(id);
            if (criminal == null)
            {
                return HttpNotFound();
            }
            return View(criminal);
        }

        // GET: /Criminal/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Criminal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CriminalID,FirstName,LastName,EyeColor,Weight,Height,Gender,Ssn,Alias,HairColor,KnownAffiliates,DateOfBirth,Race,Address,State,ZipCode,PhoneNumber,misc")] Criminal criminal)
        {
            if (ModelState.IsValid)
            {
                db.Criminals.Add(criminal);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(criminal);
        }

        // GET: /Criminal/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criminal criminal = db.Criminals.Find(id);
            if (criminal == null)
            {
                return HttpNotFound();
            }
            return View(criminal);
        }

        // POST: /Criminal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CriminalID,FirstName,LastName,EyeColor,Weight,Height,Gender,Ssn,Alias,HairColor,KnownAffiliates,DateOfBirth,Race,Address,State,ZipCode,PhoneNumber,misc")] Criminal criminal)
        {
            if (ModelState.IsValid)
            {
                db.Entry(criminal).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(criminal);
        }

        // GET: /Criminal/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Criminal criminal = db.Criminals.Find(id);
            if (criminal == null)
            {
                return HttpNotFound();
            }
            return View(criminal);
        }

        // POST: /Criminal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Criminal criminal = db.Criminals.Find(id);
            db.Criminals.Remove(criminal);
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
