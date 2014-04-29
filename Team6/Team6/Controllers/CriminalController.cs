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
using System.IO;
using System.Web.Helpers;
namespace Team6.Controllers
{
    public class CriminalController : Controller
    {
        private Team6Context db = new Team6Context();
        //FileStream fs = new FileStream("C:/Users/Muhammad Naviwala/Documents/GitHub/criminal_queries.log", FileMode.OpenOrCreate);

        // GET: /Criminal/
        public ActionResult Index()
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            return View(db.Criminals.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList());
        }

        // GET: /Criminal/Details/5
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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            return View();
        }
        

        // POST: /Criminal/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CriminalID,FirstName,LastName,EyeColor,Weight,Height,Gender,Ssn,Alias,HairColor,KnownAffiliates,DateOfBirth,Race,Address,City,State,ZipCode,PhoneNumber,misc,Photo")] Criminal criminal, FormCollection formCollection, HttpPostedFileBase file)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Photos"), fileName);
                file.SaveAs(path);
                criminal.image = "~/Photos/" + fileName;
            }
            if (criminal.image == null)
            {
                criminal.image="~/Photos/unknown.jpg";
            }
            
            string Heightvalue = formCollection["HeightFeet"];
            string Heightvalue2 = formCollection["HeightInches"];
            
            criminal.Height = Convert.ToInt32( Heightvalue) * 12 + Convert.ToInt32(Heightvalue2);
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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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
        public ActionResult Edit([Bind(Include = "CriminalID,FirstName,LastName,EyeColor,Weight,Height,Gender,Ssn,Alias,HairColor,KnownAffiliates,DateOfBirth,Race,Address,City,State,ZipCode,PhoneNumber,misc")] Criminal criminal, FormCollection formCollection, HttpPostedFileBase file)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath("~/Photos"), fileName);
                file.SaveAs(path);
                criminal.image = "~/Photos/" + fileName;
            }
            if (criminal.image == null)
            {
                criminal.image = "~/Photos/unknown.jpg";
            }

            string Heightvalue = formCollection["HeightFeet"];
            string Heightvalue2 = formCollection["HeightInches"];

            criminal.Height = Convert.ToInt32(Heightvalue) * 12 + Convert.ToInt32(Heightvalue2);
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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
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

        public ActionResult SearchCriminal(string firstName, string lastName, string weight, string height, string ssn, string address, string zipCode, Race race, State state, Gender gender, EyeColor eyeColor, HairColor hairColor)
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            var context = new Team6Context();
            string sqlQuery = "SELECT * FROM dbo.Criminal";
            bool cont = false;

            if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(weight) && string.IsNullOrEmpty(height) && string.IsNullOrEmpty(ssn) && string.IsNullOrEmpty(address) && string.IsNullOrEmpty(zipCode) && race.Equals(Race.None) && state.Equals(State.None) && gender.Equals(Gender.None) && eyeColor.Equals(EyeColor.None) && hairColor.Equals(HairColor.None))
            {
                // some error message that the user should enter at least one field
            }
            else
            {
                sqlQuery = "SELECT * FROM dbo.Criminal WHERE ";

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

                if (!string.IsNullOrEmpty(weight))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "Weight LIKE \'%" + Convert.ToInt32(weight) + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(height))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "Height LIKE \'%" + Convert.ToInt32(height) + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(ssn))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "Ssn LIKE \'%" + Convert.ToInt32(ssn) + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(address))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    address = address.Replace("'", "''");
                    sqlQuery += "Address LIKE \'%" + address + "%\'";
                    cont = true;
                }

                if (!string.IsNullOrEmpty(zipCode))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "ZipCode LIKE \'%" + Convert.ToInt32(zipCode) + "%\'";
                    cont = true;
                }

                if (!race.Equals(Race.None))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "Race = " + Convert.ToInt32(race);
                    cont = true;
                }

                if (!state.Equals(State.None))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "State = " + Convert.ToInt32(state);
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

                if (!hairColor.Equals(HairColor.None))
                {
                    if (cont)
                        sqlQuery += " AND ";
                    sqlQuery += "HairColor = " + Convert.ToInt32(hairColor);
                    cont = true;
                }

            }
            
            //using (StreamWriter _writer = new StreamWriter(fs))
            //{
            //    _writer.WriteLine(sqlQuery);
            //}

            var criminals = context.Criminals.SqlQuery(sqlQuery);
            return View(criminals.OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList());
        }
    }
}
