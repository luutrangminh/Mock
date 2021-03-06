﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business;
using System.ComponentModel.DataAnnotations;

namespace Administrator.Models
{
    public class ProfessorViewModel
    {
        public int id { get; set; }
        [Required (ErrorMessage = "Không được để trống.")]
        [Display(Name = "Họ Tên")]
        public string fullName { get; set; }
        [Required (ErrorMessage = "Không được để trống.")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email chưa chính xác. Vui lòng kiểm tra lại.")]
        public string email { get; set; }
        [Required (ErrorMessage = "Không được để trống.")]
        [Display(Name = "Tài Khoản")]
        [StringLength(20, ErrorMessage = "Tài khoản có từ 5 ký tự đến 20 ký tự.", MinimumLength = 5)]
        public string username { get; set; }
        [Required (ErrorMessage = "Không được để trống.")]
        [Display(Name = "Mật Khẩu")]
        [StringLength(32, ErrorMessage = "Mật khẩu có từ 5 ký tự đến 32 ký tự.", MinimumLength = 5)]
        public string password { get; set; }
        [Required (ErrorMessage = "Không được để trống.")]
        [Display(Name = "SĐT")]
        [Range(0800000001,09999999999,ErrorMessage = "Số điện thoại phải là số và có 10 hoặc 11 ký tự.")]
        public string phoneNumber { get; set; }
        [Required (ErrorMessage = "Không được để trống.")]
        [Display(Name = "Địa Chỉ")]
        public string address { get; set; }
        public int createdBy { get; set; }
        [Required (ErrorMessage = "Không được để trống.")]
        [Display(Name = "Admin")]
        public string createdByStr { get; set; }
        [Required (ErrorMessage = "Không được để trống.")]
        [Display(Name = "Ngày Tạo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime createdAt { get; set; }
        public byte[] avatar { get; set; }

        public ProfessorViewModel(Business.propProfessor obj)
        {
            this.id = obj.id;
            this.fullName = obj.fullName;
            this.email = obj.email;
            this.username = obj.username;
            this.password = obj.password;
            this.phoneNumber = obj.phoneNumber;
            this.address = obj.address;
            this.createdBy = obj.createdBy;
            this.createdAt = obj.createdAt;
            this.createdByStr = obj.createdByStr;
            this.avatar = obj.avatar;
        }
    }
}