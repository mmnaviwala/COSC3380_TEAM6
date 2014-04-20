﻿using System;
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
            return View(db.Officers.ToList());
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
        public ActionResult Create([Bind(Include="OfficerID,BadgeNumber,Rank,FirstName,LastName,UserName,Password,PhoneNumber,Email,Ssn,EyeColor,Height,Gender")] Officer officer)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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

        // POST: /Officer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="OfficerID,BadgeNumber,Rank,FirstName,LastName,UserName,Password,PhoneNumber,Email,Ssn,EyeColor,Height,Gender")] Officer officer)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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
            return View(officers1.ToList());
        }
    }
}
