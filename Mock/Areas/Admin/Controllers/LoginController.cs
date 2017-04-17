using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mock.Areas.Admin.Models;

namespace Mock.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        OnlineTestEntities db = new OnlineTestEntities();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            var username = f["Username"];
            var password = f["Password"];
            foreach (var item in db.Administrators)
            {
                if (username == item.Username)
                {
                    if(password == item.Password)
                    {
                        return RedirectToAction("Index","Professors");
                    }
                    else
                    {
                        ViewBag.Password = "Mật khẩu không chính xác. Vui lòng kiểm tra lại.";
                    }
                }
                else
                {
                    ViewBag.Username = "Tài khoản không tồn tại. Vui lòng kiểm tra lại.";
                }

            }
            return View();
        }
    }
}