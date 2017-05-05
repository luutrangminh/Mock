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
            var professor = Business.Professor.Get("nguyenthanh");
            var professor2 = Business.Professor.Get("nguyenthanh");
            ViewBag.Professor = professor;
            return View();
        }

        //
        // GET: /Project/Details/5
        [Route("project/details")]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Project/Create
        [Route("project/create")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Project/Create
        [HttpPost]
        [Route("project/create")]
        public ActionResult Create(ProjectViewModel model)
        {
            Project.Add(model.code, model.name, model.createdAt, model.iCreatedBy, model.startAt, model.time);
            return View();
        }

        //
        // GET: /Project/Edit/5
        [Route("project/edit/{id}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Project/Edit/5
        [HttpPost]
        [Route("project/edit/{id}")]
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
        [Route("project/del/{id}")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Project/Delete/5
        [HttpPost]
        [Route("project/del/{id}")]
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
