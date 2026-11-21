using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Week15_de1_ontap.Models;

public partial class TaiSan
{
    [Key]
    public int MaTs { get; set; }

    public int MaLoai { get; set; }

    [Required(ErrorMessage = "Tên không được để trống")]
    public string TenTs { get; set; } = null!;

    [Range(1, 2000, ErrorMessage = "Giá trong khoảng 1 đến 2000 tr")]
    public decimal? NguyenGia { get; set; }

    [RegularExpression(@".+\.(jpg|jpeg|png|webp)$", ErrorMessage = "Ảnh phải đúng định dạng .jpg|.jpeg|.png|.webp")]
    public string? Anh { get; set; }

    public virtual LoaiTaiSan? MaLoaiNavigation { get; set; } = null!;
}
