using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Week15_de2_ontap.Models;

public partial class LoaiTaiSan
{
    [Key]
    public int MaLoai { get; set; }

    public string TenLoai { get; set; } = null!;

    public virtual ICollection<TaiSan> TaiSans { get; set; } = new List<TaiSan>();
}
