using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoHoangDinh_241230706_ontap.Models;

public partial class LoaiHang
{
    [Key]
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<HangHoa>? HangHoas { get; set; } = new List<HangHoa>();
}
