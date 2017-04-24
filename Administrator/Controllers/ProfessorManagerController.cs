using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Administrator.Models;

namespace Administrator.Controllers
{
    public class ProfessorManagerController : Controller
    {
        // GET: ProfessorManager
        public ActionResult Index()
        {
            var listProfessorShow = new List<Administrator.Models.ProfessorViewModel>();
            var listProfessor = Business.Professor.Get();
            listProfessor.ForEach(professor =>
            {
                var admin = Business.Administrator.Get(professor.createdBy);
                var professorShow = new Administrator.Models.ProfessorViewModel(professor, admin.FullName);
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
            var username = f["username"];
            var password = f["password"];
            var fullName = f["fullName"];
            var email = f["email"];
            var phoneNumber = f["phoneNumber"];
            var address = f["address"];
            var createdAt = DateTime.Parse(f["createdAt"]);
            var createdBy = int.Parse(f["createdBy"]);
            if (ModelState.IsValid)
            {
                Business.Professor.Add(createdBy, createdAt, fullName, email, username, password, phoneNumber, address);
                return RedirectToAction("Index", "ProfessorManager");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(FormCollection f)
        {
            int id = int.Parse(f["id"]);
            Business.Professor.Delete(id);
            return RedirectToAction("Index");
        }
    }
}