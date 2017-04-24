using System;
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
        public string username { get; set; }
        [Required (ErrorMessage = "Không được để trống.")]
        [Display(Name = "Mật Khẩu")]
        public string password { get; set; }
        [Required (ErrorMessage = "Không được để trống.")]
        [Display(Name = "SĐT")]
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

        public ProfessorViewModel(Business.propProfessor obj, string createdByStr)
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
            this.createdByStr = createdByStr;
        }
    }
}