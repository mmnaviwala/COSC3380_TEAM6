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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            var errMsg = TempData["ErrorMessage"] as string;
            ViewBag.Message = errMsg;
            return View(db.Officers.OrderBy(x => x.FirstName).ThenByDescending(x => x.LastName).ToList());
        }

        // GET: /Officer/Details/5
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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            return View();
        }

        // POST: /Officer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OfficerID,BadgeNumber,Rank,FirstName,LastName,UserName,Password,PhoneNumber,Email,Ssn,EyeColor,Height,Gender")] Officer officer, FormCollection formCollection)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }


            officer.Height = Convert.ToInt32(formCollection["HeightFeet"]) * 12 + Convert.ToInt32(formCollection["HeightInches"]);
            if (ModelState.IsValid)
            {
                db.Officers.Add(officer);
                try{
                db.SaveChanges();
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Invalid information");
                    
                    return View(officer);
                }
                return RedirectToAction("Index");
            }

            return View(officer);
        }

        // GET: /Officer/Edit/5
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
            Officer officer = db.Officers.Find(id);
            if (officer == null)
            {
                return HttpNotFound();
            }
            if (officer.UserName == System.Web.HttpContext.Current.User.Identity.Name)
            {
                return View(officer);
            }
            else
            {
                TempData["ErrorMessage"] = "You are only allowed to edit your profile!";
                return RedirectToAction("Index", "Officer");
            }
        }

        // POST: /Officer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OfficerID,BadgeNumber,Rank,FirstName,LastName,UserName,Password,PhoneNumber,Email,Ssn,EyeColor,Height,Gender")] Officer officer, FormCollection formCollection)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }

            officer.Height = Convert.ToInt32(formCollection["HeightFeet"]) * 12 + Convert.ToInt32(formCollection["HeightInches"]);
            if (ModelState.IsValid)
            {
                db.Entry(officer).State = EntityState.Modified;
                try{
                db.SaveChanges();
                }
                catch (Exception)
                {

                    ModelState.AddModelError("", "Invalid information");
                    return View(officer);
                }
                return RedirectToAction("Index");
            }
            return View(officer);
        }

        // GET: /Officer/Delete/5
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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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

        public ActionResult SearchOfficer (string firstName, string lastName, string userName, string email, string phoneNumber, string ssn, string badgeNumber, Rank rank, Gender gender, EyeColor eyeColor)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            var context = new Team6Context();
            string sqlQuery = "SELECT * FROM dbo.Officer";
            bool cont = false;

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(phoneNumber) && string.IsNullOrEmpty(ssn) && string.IsNullOrEmpty(badgeNumber) && rank.Equals(Rank.None) && gender.Equals(Gender.None) && eyeColor.Equals(EyeColor.None))
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
                    firstName = firstName.Replace("'", "''");
                    sqlQuery += "FirstName LIKE \'%" + firstName + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(lastName))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    lastName = lastName.Replace("'", "''");
                    sqlQuery += "LastName LIKE \'%" + lastName + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(userName))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    userName.Replace("'", "''");
                    sqlQuery += "UserName LIKE \'%" + userName + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(email))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    email = email.Replace("'", "''");
                    sqlQuery += "Email LIKE \'%" + email + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(phoneNumber))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "PhoneNumber LIKE \'%" + Convert.ToInt32(phoneNumber) + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(ssn))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "Ssn LIKE \'%" + Convert.ToInt32(ssn) + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(badgeNumber))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "BadgeNumber LIKE \'%" + Convert.ToInt32(badgeNumber) + "%\'";
                    cont = true;
                }

                if (!rank.Equals(Rank.None))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "Rank = " + Convert.ToInt32(rank);
                    cont = true;
                }

                if (!gender.Equals(Gender.None))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "Gender = " + Convert.ToInt32(gender);
                    cont = true;
                }

                if (!eyeColor.Equals(EyeColor.None))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "EyeColor = " + Convert.ToInt32(eyeColor);
                    cont = true;
                }
            }

            var officers1 = context.Officers.SqlQuery(sqlQuery);
            return View(officers1.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList());
        }

        public ActionResult CrimeReportReports(string officerId, string badgeNumber, string firstName, string lastName, OffenseType offenseType)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            var context = new Team6Context();
            string sqlQuery = "SELECT * FROM dbo.CrimeReport";
            bool cont = false;
            string viewBagMessageString = "";

            if (string.IsNullOrEmpty(officerId) && string.IsNullOrEmpty(badgeNumber) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && offenseType.Equals(OffenseType.None))
            {
                // some error message that the user should enter at least one field
            }
            else
            {
                sqlQuery = "SELECT * FROM dbo.CrimeReport WHERE ";
                viewBagMessageString = "<b>Parameters:</b> ";

                if (!string.IsNullOrEmpty(officerId))
                {
                    if (cont)
                    {
                        sqlQuery += " AND ";
                        viewBagMessageString += ", ";
                    }
                    sqlQuery += "OfficerID LIKE \'%" + Convert.ToInt32(officerId) + "%\'";
                    viewBagMessageString += "Officer ID = " + officerId;
                    cont = true;
                }

                if (!string.IsNullOrEmpty(badgeNumber))
                {
                    if (cont)
                    {
                        sqlQuery += " AND ";
                        viewBagMessageString += ", ";
                    }
                    sqlQuery += "badgeNumber LIKE \'%" + Convert.ToInt32(badgeNumber) + "%\'";
                    viewBagMessageString += "Badge Number ID = " + badgeNumber;
                    cont = true;
                }

                if (!string.IsNullOrEmpty(firstName))
                {
                    if (cont)
                    {
                        sqlQuery += " AND ";
                        viewBagMessageString += ", ";
                    }
                    firstName = firstName.Replace("'", "''");
                    sqlQuery += ("FirstName LIKE \'%" + firstName + "%\'");
                    viewBagMessageString += "First Name = " + firstName;
                    cont = true;
                }

                if (!string.IsNullOrEmpty(lastName))
                {
                    if (cont)
                    {
                        sqlQuery += " AND ";
                        viewBagMessageString += ", ";
                    }
                    lastName = lastName.Replace("'", "''");
                    sqlQuery += ("LastName LIKE \'%" + lastName + "%\'");
                    viewBagMessageString += "Last Name = " + lastName;
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
