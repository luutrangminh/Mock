using Professor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptography;
using Business;

namespace Professor.Controllers
{
    public class ProjectController : Controller
    {
        // GET: /Project/
        [Route("project")]
        public ActionResult Index()
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            var projectList = Business.Project.GetByProfessor(account.id);
            ViewBag.ProjectList = projectList;
            return View();
        }

        //
        // GET: /Project/Details/5
        [Route("project/details")]
        public ActionResult Details(int id)
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            return View();
        }

        //
        // GET: /Project/Create
        [Route("project/create")]
        public ActionResult Create()
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            return View();
        }

        //
        // POST: /Project/Create
        [HttpPost]
        [Route("project/create")]
        public ActionResult Create(ProjectViewModel model)
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            Project.Add(model.name, model.createdAt, model.iCreatedBy, model.startAt, model.time);
            return View();
        }

        //
        // GET: /Project/Edit/5
        [Route("project/edit/{id}")]
        public ActionResult Edit(int id)
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            return View();
        }

        //
        // POST: /Project/Edit/5
        [HttpPost]
        [Route("project/edit/{id}")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Project/Delete/5
        [Route("project/del")]
        public ActionResult Delete()
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            return View();
        }

        //
        // POST: /Project/Delete/5
        [HttpPost]
        [Route("project/del")]
        public ActionResult Delete(FormCollection collection)
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            var projectId = int.Parse(collection["id"]);
            if (!Project.VerifyByProfessor(account.id, projectId))
            {
                return Json("Permission Denied", JsonRequestBehavior.AllowGet);
            }
            else
            {
                Project.Delete(projectId);
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
