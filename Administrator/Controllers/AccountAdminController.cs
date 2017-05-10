using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Administrator.Controllers
{
    public class AccountAdminController : Controller
    {
        // GET: AccountAdmin
        [HttpGet]
        public ActionResult Index()
        {
            var admin = (Business.propAdmin)Session["admin"];
            ViewBag.Admin = admin;
            return View();
        }

        [HttpPost]
        public ActionResult Avatar(FormCollection collection)
        {
            var admin = (Business.propAdmin)Session["admin"];
            if (admin == null) return RedirectToAction("Index", "Login");
            var avatar = collection["avatar"];
            Console.WriteLine(avatar);
            if (avatar == null) return RedirectToAction("Index");
            admin.Avatar = Convert.FromBase64String(avatar.Replace("data:image/png;base64,", ""));
            Business.Professor.Update(admin.Id, admin.Avatar);
            Session["admin"] = admin;

            return RedirectToAction("Index");
        }
    }
}