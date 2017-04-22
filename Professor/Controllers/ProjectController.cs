using Professor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptography;

namespace Professor.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        //[Route("")]
        public ActionResult Index()
        {
            var projectView = new ProjectViewModel();
            projectView.name = "Test View";
            projectView.code = _SHA1.Hash("ád");
            return View(projectView);
        }

        //
        // GET: /Project/Details/5
        [Route("details")]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Project/Create
        [Route("create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Project/Create
        [HttpPost]
        [Route("create")]
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
        // GET: /Project/Edit/5
        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Project/Edit/5
        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit(int id, FormCollection collection)
        {
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
        [Route("del/{id}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Project/Delete/5
        [HttpPost]
        [Route("del/{id}")]
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
