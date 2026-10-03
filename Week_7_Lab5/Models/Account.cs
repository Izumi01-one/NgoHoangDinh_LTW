using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Week_7_Lab5.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set;  }

        [
            Display(Name = "Họ và Tên"),
            Required(ErrorMessage = "Họ tên không được để trống"),
            MinLength(6, ErrorMessage = "Họ tên ít nhất là 6 kí tự"),
            MaxLength(20, ErrorMessage = "Họ tên tối da là 20 kí tự")
        ]
        public string FullName { get; set; }

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Địa chỉ email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        [DataType(DataType.PhoneNumber)]
        [Remote(action: "VerifyPhone", controller: "Account")]
        [Required(ErrorMessage = "Số điện thọi không được để trống")]
        public string Phone { get; set; }

        [Display(Name = "Địa chỉ thường trú")]
        [Required(ErrorMessage = "Địa chỉ thường trú không được để trống")]
        [StringLength(35, ErrorMessage = "Địa chỉ không vượt quá 35 kí tự")]
        public string Address { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime BirthDay { get; set; }

        [Display(Name = "Giới tính")]
        public string Gender { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Link Facebook cá nhân")]
        [Required(ErrorMessage = "Link Facebook không được để trống")]
        [Url(ErrorMessage = "Url pahỉ đúng định dạng bao gồm http/https")]
        public string Facebook { get; set; }
    }
}
