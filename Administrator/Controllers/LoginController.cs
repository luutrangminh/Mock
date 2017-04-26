using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptography;

namespace Administrator.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            var admin = (Business.propAdmin)Session["admin"];
            if (admin == null) return View();
            return RedirectToAction("Index","ProfessorManager");
        }

        [HttpPost]
        public ActionResult Index(FormCollection f)
        {
            var username = f["Username"];
            var password = f["Password"];
            var item = Business.Administrator.Get(username);
            if (item != null)
            {
                if (_MD5.Verify(password, item.Password))
                {
                    Session["admin"] = item;
                    return RedirectToAction("Index", "ProfessorManager", new { fullName = item.FullName.ToLower().Replace(" ", "-") });
                }
                else
                {
                    ViewBag.ThongBao = "Tài khoản hoặc Mật khẩu không chính xác. Vui lòng kiểm tra lại.";
                    return View();
                }
            }
            else
            {
                ViewBag.ThongBao = "Tài khoản hoặc Mật khẩu không chính xác. Vui lòng kiểm tra lại.";
                return View();
            }
        }
    }
}