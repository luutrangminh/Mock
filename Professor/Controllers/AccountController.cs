using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Professor.Models;
using Business;

namespace Professor.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("profile")]
        public ActionResult Index()
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            return View();
        }

        [HttpGet]
        [Route("profile/status")]
        public ActionResult Status(string returnURL)
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            Business.Professor.Update(account.id, !account.status);
            account = Business.Professor.Get(account.id);
            Session["account"] = account;
            return RedirectToLocal(returnURL);
        }

        [HttpGet]
        [Route("profile/edit")]
        public ActionResult Edit()
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            return View();
        }

        [HttpPost]
        [Route("profile/edit")]
        public ActionResult Edit(FormCollection collection)
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            account.fullName = collection["fullName"].Equals("") ? account.fullName : collection["fullName"];
            account.email = collection["email"].Equals("") ? account.email : collection["email"];
            account.address = collection["address"].Equals("") ? account.address : collection["address"];
            account.phoneNumber = collection["phone"].Equals("") ? account.phoneNumber : collection["phone"];
            account.avatar = collection["avatar"].Equals("") ? account.avatar : Convert.FromBase64String(collection["avatar"]);
            Business.Professor.Update(account.id, account.fullName, account.email, account.address, account.phoneNumber, account.avatar);
            Session["account"] = account;
            return View();
        }

        [HttpPost]
        [Route("profile/avatar")]
        public ActionResult Avatar(FormCollection collection)
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            var avatar = collection["avatar"];
            Console.WriteLine(avatar);
            if (avatar == null) return RedirectToAction("Index");
            account.avatar = Convert.FromBase64String(avatar.Replace("data:image/png;base64,", ""));
            Business.Professor.Update(account.id, account.avatar);
            Session["account"] = account;
            
            return RedirectToAction("Index");
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