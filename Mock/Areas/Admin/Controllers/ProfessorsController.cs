using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mock.Areas.Admin.Models;

namespace Mock.Areas.Admin.Controllers
{
    public class ProfessorsController : Controller
    {
        private OnlineTestEntities db = new OnlineTestEntities();

        // GET: Admin/Professors
        public ActionResult Index()
        {
            var professors = db.Professors.Include(p => p.Administrator);
            return View(professors.ToList());
        }

        // GET: Admin/Professors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Admin/Professors/Create
        public ActionResult Create()
        {
            ViewBag.CreatedBy = new SelectList(db.Administrators, "Id", "FullName");
            return View();
        }

        // POST: Admin/Professors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FullName,Email,Username,Password,PhoneNumber,Address,CreatedBy,CreatedAt")] Professor professor, FormCollection f)
        {
            var username = f["Username"];
            var password = f["Password"];
            var passwordconfirm = f["PasswordConfirm"];
            var date = DateTime.Now;
            professor.CreatedAt = date;
            foreach (var item in db.Professors)
            {
                if (username == item.Username)
                {
                    ViewBag.UsernameCoincidient = "Tài khoản đã có người sử dụng.";
                    ViewBag.CreatedBy = new SelectList(db.Administrators, "Id", "FullName", professor.CreatedBy);
                    return View(professor);
                }
            }

            if (ModelState.IsValid && passwordconfirm != null)
            {
                if (password != passwordconfirm)
                {
                    ViewBag.PasswordConfirm = "Mật khẩu xác nhận không chính xác.";
                    ViewBag.CreatedBy = new SelectList(db.Administrators, "Id", "FullName", professor.CreatedBy);
                    return View(professor);
                }
                else
                {
                    db.Professors.Add(professor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.PasswordConfirm = "Vui lòng nhập đầy đủ dữ liệu.";
                ViewBag.CreatedBy = new SelectList(db.Administrators, "Id", "FullName", professor.CreatedBy);
                return View(professor);
            }
        }

        // GET: Admin/Professors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatedBy = new SelectList(db.Administrators, "Id", "FullName", professor.CreatedBy);
            return View(professor);
        }

        // POST: Admin/Professors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,Email,Username,Password,PhoneNumber,Address,CreatedBy,CreatedAt")] Professor professor, FormCollection f)
        {
            var password = f["Password"];
            var passwordconfirm = f["PasswordConfirm"];
            if (ModelState.IsValid && passwordconfirm != null)
            {
                if (password != passwordconfirm)
                {
                    ViewBag.PasswordConfirm = "Mật khẩu xác nhận không chính xác.";
                    ViewBag.CreatedBy = new SelectList(db.Administrators, "Id", "FullName", professor.CreatedBy);
                    return View(professor);
                }
                else
                {
                    db.Entry(professor).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (passwordconfirm == null)
                {
                    ViewBag.PasswordConfirm = "Vui lòng nhập đầy đủ dữ liệu.";
                }
                ViewBag.CreatedBy = new SelectList(db.Administrators, "Id", "FullName", professor.CreatedBy);
                return View(professor);
            }
        }

        // GET: Admin/Professors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Admin/Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor professor = db.Professors.Find(id);
            db.Professors.Remove(professor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
