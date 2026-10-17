using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace Week_9_Entity_CRUD.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên banner không được để trống")]
        [StringLength(100)]
        public string Name { get; set; }
        public byte Status { get; set; } = 1;
        public int Priority { get; set; } = 0;

        [StringLength(100)]
        public string? Image { get; set; }

        [StringLength(350)]
        public string? Description { get; set; }
    }
}
