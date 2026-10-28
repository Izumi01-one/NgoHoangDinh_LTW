using System.ComponentModel.DataAnnotations;
using Lab3.Models;
namespace Lab3.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên bắt buộc nhập")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Tên phải có ít nhất 3 ký tự")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Email bắt buộc nhập")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@gmail.com", ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [Required(ErrorMessage = "Mật khẩu bắt buộc nhập")]
        [MinLength(8, ErrorMessage = "Mật khẩu phải có ít nhất 8 ký tự")]
        [RegularExpression(
        @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\w\s]).{8,}$",
        ErrorMessage = "Mật khẩu phải có chữ hoa, chữ thường, chữ số và ký tự đặc biệt")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Chi nhánh bắt buộc nhập")]
        public Branch? Branch { get; set; }

        [Required(ErrorMessage = "Giới tính bắt buộc nhập")]
        public Gender? Gender { get; set; }
        public bool IsRegular { get; set; }

        [Required(ErrorMessage = "Địa chỉ bắt buộc nhập")]
        [DataType(DataType.MultilineText)]
        public string? Address { get; set; }

        [Range(typeof(DateTime), "1/1/1963", "31/12/2005")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Ngày sinh bắt buộc nhập")]
        public DateTime DateOfBirth { get; set; }

        [Range(0, 10, ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10")]
        [Required(ErrorMessage = "Điểm bắt buộc nhập")]
        public float Score { get; set; }



    }
}
