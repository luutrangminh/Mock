using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace Professor.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public ActionResult Index()
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate", new { returnURL = new Uri(HttpContext.Request.Url.AbsoluteUri).OriginalString });
            ViewBag.Account = account;
            return View();
        }

        [Route("about")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Route("contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}