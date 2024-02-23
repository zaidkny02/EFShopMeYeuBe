using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class Hang
{
    public int MaHang { get; set; }

    public string TenHang { get; set; } = null!;

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
