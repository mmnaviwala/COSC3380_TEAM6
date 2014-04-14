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
    public class CrimeReportController : Controller
    {
        private Team6Context db = new Team6Context();

        // GET: /CrimeReport/
        public ActionResult Index()
        {
            return View(db.CrimeReports.ToList());
        }

        // GET: /CrimeReport/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrimeReport crimereport = db.CrimeReports.Find(id);
            if (crimereport == null)
            {
                return HttpNotFound();
            }
            return View(crimereport);
        }

        // GET: /CrimeReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CrimeReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CrimereportID,CriminalID,OfficerID,CaseNumber,Suspect,OffenseType,OffenseDate,AdmittedDate,PrisonAgency,Time")] CrimeReport crimereport)
        {
            if (ModelState.IsValid)
            {
                db.CrimeReports.Add(crimereport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crimereport);
        }

        // GET: /CrimeReport/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrimeReport crimereport = db.CrimeReports.Find(id);
            if (crimereport == null)
            {
                return HttpNotFound();
            }
            return View(crimereport);
        }

        // POST: /CrimeReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="CrimereportID,CriminalID,OfficerID,CaseNumber,Suspect,OffenseType,OffenseDate,AdmittedDate,PrisonAgency,Time")] CrimeReport crimereport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crimereport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crimereport);
        }

        // GET: /CrimeReport/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CrimeReport crimereport = db.CrimeReports.Find(id);
            if (crimereport == null)
            {
                return HttpNotFound();
            }
            return View(crimereport);
        }

        // POST: /CrimeReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CrimeReport crimereport = db.CrimeReports.Find(id);
            db.CrimeReports.Remove(crimereport);
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

        public ActionResult SearchCrimeReport(string criminalId, string officerId, string caseNumber, string prisonAgency)
        {
            var context = new Team6Context();
            string sqlQuery = "SELECT * FROM dbo.CrimeReport";
            bool cont = false;

            if (string.IsNullOrEmpty(criminalId) && string.IsNullOrEmpty(officerId) && string.IsNullOrEmpty(caseNumber) && string.IsNullOrEmpty(prisonAgency))
            {
                // some error message that the user should enter at least one field
            }
            else
            {
                sqlQuery = "SELECT * FROM dbo.CrimeReport WHERE ";

                if (!string.IsNullOrEmpty(criminalId))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "CriminalID = " + Convert.ToInt32(criminalId) + "";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(officerId))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "OfficerID = " + Convert.ToInt32(officerId) + "";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(caseNumber))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "CaseNumber = \'" + caseNumber + "\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(prisonAgency))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "PrisonAgency = \'" + prisonAgency + "\'";
                    cont = true;
                }

            }

            var crimeReports = context.CrimeReports.SqlQuery(sqlQuery);
            return View(crimeReports.ToList());
        }
    }
}
