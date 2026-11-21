using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoHoangDinh_241230706_ontap.Models;

public partial class HangHoa
{
    [Key]
    public int MaHang { get; set; }

    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Tên không được để trống")]
    public string TenHang { get; set; } = null!;

    [Required(ErrorMessage = "Giá không được để trống")]
    [Range(100, 5000, ErrorMessage = "Giá trong khoảng 100 đến 5000")]
    public decimal? Gia { get; set; }

    [Required(ErrorMessage = "Ảnh không được để trống")]
    [RegularExpression(@".+\.(jpg|png|gif|tiff)$", ErrorMessage = "Ảnh phải đúng định dạng jpg|png|gif|tiff")]
    public string? Anh { get; set; }

    public virtual LoaiHang? MaLoaiNavigation { get; set; } = null!;
}
