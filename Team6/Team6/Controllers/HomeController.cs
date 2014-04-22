using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Team6.Models;

namespace Team6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            return View();
        }

        public ActionResult About()
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            if (!(System.Web.HttpContext.Current.User != null && System.Web.HttpContext.Current.User.Identity.IsAuthenticated))
            {
                return RedirectToAction("LogOn", "Home");
            }
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult LogOn()
        {

            
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(Officer mod, string URL)
        {
            if (ModelState.IsValid)
            {
                Officer user = new Officer();
                string password = user.getUserPassword(mod.UserName);

                if (string.IsNullOrEmpty(password))
                {
                    ModelState.AddModelError("", "The username or password is incorrect");


                }
                if (mod.Password == password)
                {

                    //FormsAuthentication.SetAuthCookie(mod.UserName, false);
                    /*string userData = "ApplicationSpecific data for this user.";

      FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
        username,
        DateTime.Now,
        DateTime.Now.AddMinutes(30),
        isPersistent,
        userData,
        FormsAuthentication.FormsCookiePath);

      // Encrypt the ticket.
      string encTicket = FormsAuthentication.Encrypt(ticket);

      // Create the cookie.
      Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

      // Redirect back to original URL.
      Response.Redirect(FormsAuthentication.GetRedirectUrl(username, isPersistent));*/
                    string userData = user.getUserRank(mod.UserName);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, mod.UserName, DateTime.Now, DateTime.Now.AddMinutes(30), true, userData, FormsAuthentication.FormsCookiePath);
                    string encticket = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encticket));
                    
                    if (Url.IsLocalUrl(URL) && URL.Length > 1 && URL.StartsWith("/") && !URL.StartsWith("//") && !URL.StartsWith("/\\"))
                    {
                        return Redirect(URL);

                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The username or password you entered is incorrect");
                }
            }

            return View(mod);

        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("LogOn", "Home");
        }
    }
}