using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using Cryptography;

namespace Professor.Controllers
{
    public class AuthenticateController : Controller
    {
        //
        // GET: /Login/
        [HttpGet]
        [Route("login")]
        public ActionResult Login(string returnURL)
        {
            ViewBag.ReturnUrl = returnURL;
            var account = (propProfessor)Session["account"];
            if (account != null) return RedirectToLocal(returnURL);
            return View();
        }

        //
        // POST: /Login
        [HttpPost]
        [Route("login")]
        public ActionResult Login(FormCollection collection, string returnURL)
        {
            var username = collection["username"];
            var password = collection["password"];
            var account = Business.Professor.Get(username);
            if (account != null && 
               _MD5.Verify(password, account.password))
            {
                
                Session["account"] = account;
                return RedirectToLocal(returnURL);
            }

            ModelState.AddModelError("login", "Invalid username or password.");
            return View();
        }

        [HttpGet]
        [Route("logout")]
        public ActionResult Logout()
        {
            Session["account"] = null;
            return RedirectToAction("Login");
        }

        #region Helper

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion
    }
}
