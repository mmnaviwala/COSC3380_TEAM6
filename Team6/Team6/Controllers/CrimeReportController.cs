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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            return View(db.CrimeReports.OrderBy(x => x.CaseNumber).ToList());
        }

        // GET: /CrimeReport/Details/5
        public ActionResult Details(int? id)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            return View();
        }

        // POST: /CrimeReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="CrimereportID,CriminalID,OfficerID,CaseNumber,Suspect,OffenseType,OffenseDate,AdmittedDate,PrisonAgency,Time")] CrimeReport crimereport)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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

        public ActionResult SearchCrimeReport(string criminalId, string officerId, string caseNumber, string prisonAgency, OffenseType offenseType)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            var context = new Team6Context();
            string sqlQuery = "SELECT * FROM dbo.CrimeReport";
            bool cont = false;

            if (string.IsNullOrEmpty(criminalId) && string.IsNullOrEmpty(officerId) && string.IsNullOrEmpty(caseNumber) && string.IsNullOrEmpty(prisonAgency) && offenseType.Equals(OffenseType.None))
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
                    sqlQuery += "CriminalID LIKE \'%" + Convert.ToInt32(criminalId) + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(officerId))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "OfficerID LIKE \'%" + Convert.ToInt32(officerId) + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(caseNumber))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    caseNumber = caseNumber.Replace("'", "''");
                    sqlQuery += "CaseNumber LIKE \'%" + caseNumber + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(prisonAgency))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    prisonAgency = prisonAgency.Replace("'", "''");
                    sqlQuery += ("PrisonAgency LIKE \'%" + prisonAgency + "%\'");
                    cont = true;
                }

                if (!offenseType.Equals(OffenseType.None))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "OffenseType = " + Convert.ToInt32(offenseType);
                    cont = true;
                }

            }

            var crimeReports = context.CrimeReports.SqlQuery(sqlQuery);
            return View(crimeReports.OrderBy(x => x.CaseNumber).ToList());
        }



        public ActionResult CrimeReportReports(string criminalId, string officerId, string caseNumber, string prisonAgency, OffenseType offenseType)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            var context = new Team6Context();
            string sqlQuery = "SELECT * FROM dbo.CrimeReport";
            bool cont = false;
            string viewBagMessageString = "";

            if (string.IsNullOrEmpty(criminalId) && string.IsNullOrEmpty(officerId) && string.IsNullOrEmpty(caseNumber) && string.IsNullOrEmpty(prisonAgency) && offenseType.Equals(OffenseType.None))
            {
                // some error message that the user should enter at least one field
            }
            else
            {
                sqlQuery = "SELECT * FROM dbo.CrimeReport WHERE ";
                viewBagMessageString = "<b>Parameters:</b> ";

                if (!string.IsNullOrEmpty(criminalId))
                {
                    if (cont)
                    {
                        sqlQuery += " AND ";
                        viewBagMessageString += ", ";
                    }
                    sqlQuery += "CriminalID LIKE \'%" + Convert.ToInt32(criminalId) + "%\'";
                    viewBagMessageString += "Criminal ID = " + criminalId;
                    cont = true;
                }

                if (!string.IsNullOrEmpty(officerId))
                {
                    if (cont)
                    {
                        sqlQuery += " AND ";
                        viewBagMessageString += ", ";
                    }
                    sqlQuery += "OfficerID LIKE \'%" + Convert.ToInt32(officerId) + "%\'";
                    viewBagMessageString += "Office ID = " + officerId;
                    cont = true;
                }

                if (!string.IsNullOrEmpty(caseNumber))
                {
                    if (cont)
                    {
                        sqlQuery += " AND ";
                        viewBagMessageString += ", ";
                    }
                    caseNumber = caseNumber.Replace("'", "''");
                    sqlQuery += "CaseNumber LIKE \'%" + caseNumber + "%\'";
                    viewBagMessageString += "Case Number = " + caseNumber;
                    cont = true;
                }

                if (!string.IsNullOrEmpty(prisonAgency))
                {
                    if (cont)
                    {
                        sqlQuery += " AND ";
                        viewBagMessageString += ", ";
                    }
                    prisonAgency = prisonAgency.Replace("'", "''");
                    sqlQuery += ("PrisonAgency LIKE \'%" + prisonAgency + "%\'");
                    viewBagMessageString += "Prison Agency = " + prisonAgency;
                    cont = true;
                }

                if (!offenseType.Equals(OffenseType.None))
                {
                    if (cont)
                    {
                        sqlQuery += " AND ";
                        viewBagMessageString += ", ";
                    }
                    sqlQuery += "OffenseType = " + Convert.ToInt32(offenseType);
                    viewBagMessageString += "Offense Type = " + offenseType;
                    cont = true;
                }

            }

            var crimeReports = context.CrimeReports.SqlQuery(sqlQuery);
            if (viewBagMessageString != "")
            {
                viewBagMessageString += "<br><b>Count:</b> " + crimeReports.Count();
            }

            ViewBag.Message = viewBagMessageString;
            return View(crimeReports.OrderBy(x => x.CaseNumber).ToList());
        }

    }
}
