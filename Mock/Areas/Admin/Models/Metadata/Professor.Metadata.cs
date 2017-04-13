using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mock.Areas.Admin.Models
{
    [MetadataTypeAttribute(typeof(ProfessorMetadata))]
    public partial class Professor
    {
        internal sealed class ProfessorMetadata
        {
            [Required(ErrorMessage = "Vui lòng nhập đầy đủ dữ liệu.")]
            [Display(Name = "Họ tên:")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập đầy đủ dữ liệu.")]
            [Display(Name = "Email:")]
            [EmailAddress(ErrorMessage = "Vui lòng nhập đúng địa chỉ email.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập đầy đủ dữ liệu.")]
            [Display(Name = "Tài khoản:")]
            [MinLength(5, ErrorMessage = "Tài khoản phải có 5 ký tự trở lên.")]
            [MaxLength(20, ErrorMessage = "Tài khoản tối đa 20 ký tự.")]
            public string Username { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập đầy đủ dữ liệu.")]
            [Display(Name = "Mật khẩu:")]
            [MinLength(5, ErrorMessage = "Mật khẩu phải có 3 ký tự trở lên.")]
            [MaxLength(20, ErrorMessage = "Mật khẩu tối đa 16 ký tự.")]
            public string Password { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập đầy đủ dữ liệu.")]
            [Display(Name = "Điện thoại:")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập đầy đủ dữ liệu.")]
            [Display(Name = "Địa chỉ:")]
            public string Address { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập đầy đủ dữ liệu.")]
            [Display(Name = "Tạo bởi:")]
            public int CreatedBy { get; set; }

            [Required(ErrorMessage = "Vui lòng nhập đầy đủ dữ liệu.")]
            [Display(Name = "Ngày tạo:")]
            public System.DateTime CreatedAt { get; set; }
        }
    }
}