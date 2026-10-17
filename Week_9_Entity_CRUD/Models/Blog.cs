using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Week_9_Entity_CRUD.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên blog không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }
        public byte Status { get; set; } = 1;
        public DateTime CreatedDate { get; set; } = DateTime.Today;

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(350)]
        public string? Description { get; set; }
    }
}
