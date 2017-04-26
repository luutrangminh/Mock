using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Administrator.Models;
using Cryptography;

namespace Administrator.Controllers
{
    public class ProfessorManagerController : Controller
    {
        // GET: ProfessorManager
        [Route("{fullName}")]
        public ActionResult Index()
        {
            var adminSession = (Business.propAdmin)Session["admin"];
            if (adminSession == null) return RedirectToAction("Index", "Login");

            var listProfessorShow = new List<Administrator.Models.ProfessorViewModel>();
            var listProfessor = Business.Professor.GetByAdmin(adminSession.Id);
            listProfessor.ForEach(professor =>
            {
                var professorShow = new Administrator.Models.ProfessorViewModel(professor);
                listProfessorShow.Add(professorShow);
            });
            return View(listProfessorShow);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            if (f["createdAt"] == "")
            {
                ViewBag.Date = "Không được để trống.";
                return View();
            }
            var username = f["username"];
            var password = f["password"];
            var fullName = f["fullName"];
            var email = f["email"];
            var phoneNumber = f["phoneNumber"];
            var address = f["address"];
            DateTime createdAt = DateTime.Now;
            var admin = (Business.propAdmin)Session["admin"];
            int createdBy = admin.Id;
            password = _MD5.Hash(password);
            foreach (var item in Business.Professor.Get())
            {
                if(username == item.username)
                {
                    ViewBag.ErrorUsername = "Tên đăng nhập đã có người sử dụng.";
                    return View();
                }
            }
            
            if (ModelState.IsValid)
            {
                Business.Professor.Add(createdBy, createdAt, fullName, email, username, password, phoneNumber, address);
                return RedirectToAction("Index", "ProfessorManager");
            }
            return View();
        }

        [Route("del/{fullName}-{id}")]
        public ActionResult Delete(int id)
        {
            Business.Professor.Delete(id);
            return RedirectToAction("Index", "ProfessorManager");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            Business.propProfessor pfs = Business.Professor.Get(id);
            ViewBag.fullName = pfs.fullName;
            ViewBag.username = pfs.username;
            ViewBag.password = pfs.password;
            ViewBag.email = pfs.email;
            ViewBag.address = pfs.address;
            ViewBag.phoneNumber = pfs.phoneNumber;
            ViewBag.createdBy = pfs.createdBy;
            ViewBag.createdAt = pfs.createdAt;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection f)
        {
            Business.propProfessor pfs = Business.Professor.Get(id);
            ViewBag.fullName = pfs.fullName;
            ViewBag.username = pfs.username;
            ViewBag.password = pfs.password;
            ViewBag.email = pfs.email;
            ViewBag.address = pfs.address;
            ViewBag.phoneNumber = pfs.phoneNumber;
            ViewBag.createdBy = pfs.createdBy;
            ViewBag.createdAt = pfs.createdAt;

            var username = f["username"];
            var password = f["password"];
            var email = f["email"];
            var fullName = f["fullName"];
            var address = f["address"];
            var phoneNumber = f["phoneNumber"];

            if (username.Count() < 5 || username.Count() > 20)
            {
                ViewBag.ErrorUsername = "Tài khoản phải từ 5 đến 20 ký tự.";
                return View();
            }
            if (password.Count() < 5 || password.Count() > 32)
            {
                ViewBag.ErrorPassword = "Mật khẩu phải từ 5 đến 32 ký tự.";
            }
            
            var Pass = pfs.password;
            if (password != Pass)
            {
                password = _MD5.Hash(password);
            }
            else
            {
                password = Pass;
            }
            foreach (var item in Business.Professor.Get())
            {
                if (username == item.username && id != item.id)
                {
                    ViewBag.ThongBao = "Tài khoản đã có người sử dụng.";
                    return View();
                }
            }
            if (ModelState.IsValid)
            {
                Business.Professor.Update(id,fullName,email,username,password,phoneNumber,address);
                return RedirectToAction("Index", "ProfessorManager");
            }
            return View();
        }

    }
}