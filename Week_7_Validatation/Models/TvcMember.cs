using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Week_7_Validatation.Models
{
    public class TvcMember
    {
        public int Id { get; set; }

        [DisplayName("Tài khoản")]
        [Required(ErrorMessage = "Tài khoản không được để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tài khoản có đọ dài từ 3-20 kí tự")]
        public string TvcUserName { get; set; }

        [DisplayName("Mật khẩu")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu tối thiểu 8 kí tự")]
        public string TvcPassword { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [DataType(DataType.EmailAddress)]
        public string TvcEmail { get; set; }

        [DisplayName("Điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập điện thoại")]
        [RegularExpression(@"^0\d{9}", ErrorMessage = "Điện thoại phải là 10 kí tự số bắt đầu bằng 0")]
        public string TvcPhone { get; set; }
    }
}
