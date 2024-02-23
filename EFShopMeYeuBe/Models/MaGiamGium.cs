using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class MaGiamGium
{
    public int MaGiamGia { get; set; }

    public int MaNv { get; set; }

    public int MaSp { get; set; }

    public double GiatriKm { get; set; }

    public virtual NhanVien MaNvNavigation { get; set; } = null!;

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
