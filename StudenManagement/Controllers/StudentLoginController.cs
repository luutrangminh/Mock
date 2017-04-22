using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
namespace StudenManagement.Controllers
{
    public class StudentLoginController : Controller
    {
        Business.StudentManagement studentBUS = new Business.StudentManagement();
        // GET: StudentLogin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection f)
        {
            string tk = f["account"].ToString();
            string mk = f["password"].ToString();

            var st = studentBUS.kiemtratkmk(tk, mk);
            string sttk = st[0].ToString().Trim();
            string stmk = st[1].ToString().Trim();
            if (sttk.Equals(tk) && stmk.Equals(mk))
            {
                Session["UserStudent"] = sttk;
                return RedirectToAction("Index", "ManageStudent");
            }
            else
            {
                ViewBag.ThongBao = "Tài khoản hoặc mật khẩu sai !";
            }
            return View();
        }
        public ActionResult Register()
        {
            ViewBag.AssignBy = new SelectList(studentBUS.laydsgs());
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection f)
        {
            ViewBag.AssignBy = new SelectList(studentBUS.laydsgs());
            string tk = f["account"].ToString().Trim();
            string mk = f["password"].ToString().Trim();
            string rmk = f["repassword"].ToString().Trim();
            string email = f["email"].ToString().Trim();
            string ten = f["name"].ToString().Trim();
            DateTime ngaysinh = DateTime.Parse(f["dateofbirth"]);
            string truong = f["college"].ToString().Trim();
            string mon = f["monhoc"].ToString().Trim();
            //string exp = f["exp"].ToString().Trim();
            int tuoi = DateTime.Now.Year - ngaysinh.Year;
            string ass = f["AssignBy"];

            var idgs = studentBUS.layidgs(ass);
            int id = int.Parse(idgs);

            if (mk != rmk)
            {
                ViewBag.Loi2 = "Mật khẩu và nhập lại mật khẩu không giống nhau !";
            }
            else
            {
                if (studentBUS.kiemtratk(tk) == "co")
                {
                    ViewBag.Loi1 = "Tài khoản đã tồn tại !";
                }
                else
                {
                    if (studentBUS.kiemtraemail(email) == "co")
                    {
                        ViewBag.Loi4 = "Email đã tồn tại !";
                    }
                    else
                    {
                        studentBUS.dangkysv(tk, mk, email, ten, truong, mon, tuoi, id, ngaysinh);
                        ViewBag.ThongBao = "Đăng ký thành công !";
                    }
                }
            }

            return View();
        }
    }
}