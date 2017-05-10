using Professor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cryptography;
using Business;
using System.Web.Script.Serialization;

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
        // POST: /Project/Create
        [HttpPost]
        [Route("project/create")]
        public ActionResult Create(FormCollection collection)
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            var name = collection["name"].ToString();
            var startDate = DateTime.Parse(collection["startDate"].ToString());
            var endDate = DateTime.Parse(collection["endDate"].ToString());
            var result = Project.Add(name, DateTime.Now, account.id, startDate, endDate);
            if (result == null) return Json(false, JsonRequestBehavior.AllowGet);
            else
            {
                return Json(result + ".Please try agian!", JsonRequestBehavior.AllowGet);
            }
        }

        //
        // POST: /Project/Edit/5
        [HttpPost]
        [Route("project/edit")]
        public ActionResult Edit(FormCollection collection)
        {
            var account = (propProfessor)Session["account"];
            if (account == null) return RedirectToAction("Login", "Authenticate");
            ViewBag.Account = account;
            var createdBy = int.Parse(collection["createdBy"].ToString());

            if (createdBy != account.id) return Json("Permission denied", JsonRequestBehavior.AllowGet); 

            var id = int.Parse(collection["id"].ToString());
            var name = collection["name"].ToString();
            var startDate = DateTime.Parse(collection["startDate"].ToString());
            var endDate = DateTime.Parse(collection["endDate"].ToString());
            var result = Project.Update(id, name, startDate, endDate);

            if (result == null) return Json(false, JsonRequestBehavior.AllowGet);
            else
            {
                return Json(result + ".Please try agian!", JsonRequestBehavior.AllowGet);
            }
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
            var ids = new JavaScriptSerializer().Deserialize<List<int>>(collection["id"].ToString());

            if (ids.Count == 0)
            {
                return Json("Don't have anything to delete. Are you ok?", JsonRequestBehavior.AllowGet);
            }

            var status = true;
            var errIds = new List<int>();
            foreach (var id in ids)
            {
                if (!Project.VerifyByProfessor(account.id, id))
                {
                    status = false;
                    errIds.Add(id);
                }
                else Project.Delete(id);
            }

            if (status) return Json(false, JsonRequestBehavior.AllowGet);
            else
            {
                string errIdsStr = null;
                errIds.ForEach(errId => errIdsStr += errId + ", ");
                return Json("Permission Denied " + errIdsStr, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
