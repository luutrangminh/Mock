using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Business;
using System.Web.Script.Serialization;

namespace Professor.Controllers
{
    public class StudentController : Controller
    {
        //
        // GET: /Students/
        [Route("assign/")]
        public ActionResult Index()
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            var listScoreBoard = Business.ScoreBoard.Get();
            var listProject = Business.Project.GetByProfessor(account.id);
            ViewBag.ProjectList = listProject;
            ViewBag.ListScoreBoard = listScoreBoard;
            return View();
        }

        //
        // GET: /Students/Details/5
        [Route("assigned")]
        public ActionResult Assigned()
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            var listAssignedGroup = Business.Group.Get(account.id);
            ViewBag.ListAssignedGroup = listAssignedGroup;
            return View();
        }

        //
        // GET: /Students/Details/5
        [Route("assigned/{code}")]
        public ActionResult Assigned(string code)
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            var listGroupMember = Business.GroupMember.Get(code);
            return Json(new JavaScriptSerializer().Serialize(listGroupMember), JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Students/Create
        [Route("assign/create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Students/Create
        [HttpPost]
        [Route("assign/create")]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Students/Edit/5
        [HttpPost]
        [Route("assign/edit")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var projectCode = collection["projectCode"].ToString();
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            var project = Business.Project.Get(projectCode);
            if (project.endDate < DateTime.Now) return Json("Project is closed", JsonRequestBehavior.AllowGet);
            Assignee.Assign(account.id, id, project.id, project.code, Url.Action("Detail", "Project", new { code = projectCode }));
            return Json(false, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Students/Delete/5
        [Route("assign/del")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Students/Delete/5
        [HttpPost]
        [Route("assign/del")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
