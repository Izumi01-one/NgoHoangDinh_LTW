using System.ComponentModel.DataAnnotations;

namespace Week_7_Lab5.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tên Category")]
        [Required(ErrorMessage = "Tên Category không được để trống")]
        [MinLength(6, ErrorMessage = "Tên Category ít nhất 6 kí tự")]
        [MaxLength(150, ErrorMessage = "Tên Category giới hạn 150 kí tự")]
        public string Name { get; set; }

        public List<Product> products = new List<Product>();

    }
}
