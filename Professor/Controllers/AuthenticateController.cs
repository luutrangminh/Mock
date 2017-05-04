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
        public ActionResult Login()
        {
            var account = (propProfessor)Session["account"];
            if (account != null) return RedirectToAction("Index", "Home");
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
