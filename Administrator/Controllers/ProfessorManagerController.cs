﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Administrator.Models;
using Cryptography;
using EmailProvider;

namespace Administrator.Controllers
{
    public class ProfessorManagerController : Controller
    {
        private string emailValidation(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                if (!EmailSender.isEmail(email))
                    return "Email không hợp lệ.";
                foreach(var item in Business.Professor.GetEmail())
                {
                    if (email == item)
                    {
                        return "Email đã tồn tại.";
                    }
                }

                return "";
            }
            return "Không được để trống.";
        }

        private string emailValidationEdit(string email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                return "";
            }
            return "Không được để trống.";
        }

        private string fullNameValidation(string fullName)
        {
            if (!string.IsNullOrEmpty(fullName))
            {
                return "";
            }

            return "Không được để trống.";
        }
        private string userNameValidation(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                if (userName.Count() < 3 || userName.Count() > 16)
                {
                    return "Tài khoản phải có 3 ký tự đến 16 ký tự.";
                }
                else
                {
                    foreach (var item in Business.Professor.GetUserName())
                    {
                        if (userName == item)
                        {
                            return "Tài khoản đã tồn tại.";
                        }
                    }
                }

                return "";
            }
            return "Không được để trống.";
        }

        private string userNameValidationEdit(string userName, int id)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                if (userName.Count() < 3 || userName.Count() > 16)
                {
                    return "Tài khoản phải có 3 ký tự đến 16 ký tự.";
                }
                else
                {
                    foreach (var item in Business.Professor.Get())
                    {
                        if (userName == item.username && id != item.id)
                        {
                            return "Tài khoản đã tồn tại.";
                        }
                    }
                }

                return "";
            }
            return "Không được để trống.";
        }

        private string passwordValidation(string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                if (password.Count() < 5 || password.Count() > 20)
                {
                    return "Mật khẩu phải có 5 ký tự đến 20 ký tự.";
                }

                return "";
            }

            return "Không được để trống.";
        }

        private string phoneNumberValidation(string phoneNumber)
        {
            if (!string.IsNullOrEmpty(phoneNumber))
            {
                return "";
            }

            return "Không được để trống.";
        }
        private string addressValidation(string address)
        {
            if (!string.IsNullOrEmpty(address))
            {
                return "";
            }

            return "Không được để trống.";
        }

        private string passwordConfirmValidation(string passwordConfirm, string password)
        {
            if (!string.IsNullOrEmpty(passwordConfirm))
            {
                if (password != passwordConfirm)
                {
                    return "Mật khẩu xác nhận không chính xác.";
                }

                return "";
            }

            return "Không được để trống";
        }

        private bool CheckValidate(string fullName, string email, string userName, string password, string passwordConfirm, string phoneNumber, string address)
        {
            bool status = false;
            
            ModelState.AddModelError("FullName", fullNameValidation(fullName));
            ModelState.AddModelError("Email", emailValidation(email));
            ModelState.AddModelError("UserName", userNameValidation(userName));
            ModelState.AddModelError("Password", passwordValidation(password));
            ModelState.AddModelError("PasswordConfirm", passwordConfirmValidation(passwordConfirm, password));
            ModelState.AddModelError("PhoneNumber", phoneNumberValidation(phoneNumber));
            ModelState.AddModelError("Address", addressValidation(address));

            if (fullNameValidation(fullName) == "" && emailValidation(email) == "" && userNameValidation(userName) == ""
                && passwordValidation(password) == "" && passwordConfirmValidation(passwordConfirm, password) == ""
                && phoneNumberValidation(phoneNumber) == "" && addressValidation(address) == "")
            {
                status = true;
            }

            return status;
        }

        private bool CheckValidateEdit(int id, string fullName, string email, string userName, string password, string passwordConfirm, string phoneNumber, string address)
        {
            bool status = false;

            ModelState.AddModelError("FullName", fullNameValidation(fullName));
            ModelState.AddModelError("Email", emailValidationEdit(email));
            ModelState.AddModelError("UserName", userNameValidationEdit(userName, id));
            ModelState.AddModelError("Password", passwordValidation(password));
            ModelState.AddModelError("PasswordConfirm", passwordConfirmValidation(passwordConfirm, password));
            ModelState.AddModelError("PhoneNumber", phoneNumberValidation(phoneNumber));
            ModelState.AddModelError("Address", addressValidation(address));

            if (fullNameValidation(fullName) == "" && emailValidationEdit(email) == "" && userNameValidationEdit(userName, id) == ""
                && passwordValidation(password) == "" && passwordConfirmValidation(passwordConfirm, password) == ""
                && phoneNumberValidation(phoneNumber) == "" && addressValidation(address) == "")
            {
                status = true;
            }

            return status;
        }

        // GET: ProfessorManager
        public ActionResult Index()
        {
            var adminSession = (Business.propAdmin)Session["admin"];
            if (adminSession == null) return RedirectToAction("Index", "Login");

            var listProfessorShow = new List<Administrator.Models.ProfessorViewModel>();
            var listProfessor = Business.Professor.GetByAdmin(adminSession.Id);
            listProfessor.ForEach(professor =>
            {
                var professorShow = new Administrator.Models.ProfessorViewModel(professor);
                listProfessorShow.Add(professorShow);
            });
            return View(listProfessorShow);
        }

        public Dictionary<string, string[]> ValidationMessageList
        {
            get
            {
                return ModelState
                .Where(x => x.Value.Errors.Count > 0)
                .ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );
            }
        }

        [HttpPost]
        public ActionResult Create(FormCollection f)
        {
            var fullName = f["fullName"];
            var email = f["email"];
            var userName = f["userName"];
            var password = f["password"];
            var passwordConfirm = f["passwordConfirm"];
            var phoneNumber = f["phoneNumber"];
            var address = f["address"];
            bool statusProfessor = false;


            var status = CheckValidate(fullName, email, userName, password, passwordConfirm, phoneNumber, address);
            if (status)
            {
                DateTime createdAt = DateTime.Now;
                var admin = (Business.propAdmin)Session["admin"];
                int createdBy = admin.Id;
                password = _MD5.Hash(password);
                Business.Professor.Add(createdBy, createdAt, fullName, email, userName, password, phoneNumber, address, statusProfessor);

                //Send Email
                string message = "Tài khoản giáo viên của bạn vừa được cấp bởi quản trị viên " + admin.FullName + " lúc " + createdAt.ToShortTimeString() + " ngày " + createdAt.ToShortDateString() + ":"
                + "<br>Thông tin tài khoản:<br>   - Tên đăng nhập: " + userName + "<br>   - Mật khẩu: " + password
                + "<br>Vui lòng đăng nhập và hoàn thành thông tin.";
                var sendStatus = EmailSender.Send(email, "Vui lòng hoàn thành thông tin giáo viên trên FreePay", message);
                if (!sendStatus)
                {
                    ViewBag.Error = "Email chưa được gửi";
                }
                //End Send Email

            }

            return Json(new
            {
                Status = status,
                Errors = this.ValidationMessageList
            });
        }

        [HttpPost]
        public JsonResult EditProfessor(FormCollection f)
        {
            var id = int.Parse(f["id"]);
            var fullName = f["fullName"];
            var email = f["email"];
            var userName = f["userName"];
            var password = f["password"];
            var phoneNumber = f["phoneNumber"];
            var address = f["address"];
            var passwordConfirm = password;

            var admin = (Business.propAdmin)Session["admin"];
            Business.propProfessor pfs = Business.Professor.Get(id);
            DateTime createdAt = pfs.createdAt;
            var status = CheckValidateEdit(id, fullName, email, userName, password, passwordConfirm, phoneNumber, address);
            if (status)
            {
                var tmp = _MD5.Hash(password);
                Business.Professor.Update(id, fullName, email, userName, tmp, phoneNumber, address);

                //Send Email
                string message = "Tài khoản giáo viên của bạn vừa được cập nhật bởi quản trị viên " + admin.FullName + " lúc " + createdAt.ToShortTimeString() + " ngày " + createdAt.ToShortDateString() + ":"
                + "<br>Thông tin tài khoản:<br>   - Tên đăng nhập: " + userName + "<br>   - Mật khẩu: " + password
                + "<br>Vui lòng đăng nhập và hoàn thành thông tin.";
                var sendStatus = EmailSender.Send(email, "Vui lòng hoàn thành thông tin giáo viên trên FreePay", message);
                if (!sendStatus)
                {
                    ViewBag.Error = "Email chưa được gửi";
                }
                //End Send Email
            }

            return Json(new
            {
                Status = status,
                Errors = this.ValidationMessageList
            });
        }

        public JsonResult Delete(FormCollection f)
        {
            bool status = false;
            int id = int.Parse(f["id"]);
            if (id != 0)
            {
                status = true;
            }
            if (status)
            {
                Business.Professor.Delete(id);
            }
            return Json(new
            {
                Status = status
            });
        }
    }
}