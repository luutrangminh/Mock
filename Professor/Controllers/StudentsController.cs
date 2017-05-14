using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Professor.Controllers
{
    public class StudentsController : Controller
    {
        //
        // GET: /Students/
        [Route("assign/")]
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Students/Details/5
        [Route("assign/detail")]
        public ActionResult Details(int id)
        {
            return View();
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
        // GET: /Students/Edit/5
        [Route("assign/edit")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Students/Edit/5
        [HttpPost]
        [Route("assign/edit")]
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
