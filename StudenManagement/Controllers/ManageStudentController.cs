using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;

namespace StudenManagement.Controllers
{
    public class ManageStudentController : Controller
    {
        Business.StudentManagement studentBUS = new Business.StudentManagement();
        // GET: ManageStudent
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UpdateInformationStudent()
        {
            var usersv = Session["UserStudent"];
            var sv = studentBUS.LayTTSV(usersv.ToString());
            string email = sv[3].ToString().Trim();
            string ten = sv[4].ToString().Trim();
            string truong = sv[5].ToString().Trim();
            string mon = sv[6].ToString().Trim();
            DateTime ngaysinh = DateTime.Parse(sv[9]);
            ViewBag.Email = email;
            ViewBag.HoTen = ten;
            ViewBag.Truong = truong;
            ViewBag.Mon = mon;
            ViewBag.NgaySinh = ngaysinh;

            ViewBag.AssignBy = new SelectList(studentBUS.laydsgs());
            return View();
        }
    }
}