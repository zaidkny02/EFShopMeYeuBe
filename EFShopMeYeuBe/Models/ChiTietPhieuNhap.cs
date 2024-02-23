using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class ChiTietPhieuNhap
{
    public int MaP { get; set; }

    public int MaSp { get; set; }

    public int SoLnhap { get; set; }

    public string Size { get; set; } = null!;

    public virtual ChiTietSanPham ChiTietSanPham { get; set; } = null!;

    public virtual PhieuNhapHang MaPNavigation { get; set; } = null!;
}
