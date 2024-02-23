using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class LoaiSanPham
{
    public int MaLoaiSp { get; set; }

    public string TenLsp { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
