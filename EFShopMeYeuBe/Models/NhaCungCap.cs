using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class NhaCungCap
{
    public int MaNcc { get; set; }

    public string TenNcc { get; set; } = null!;

    public string Sdtncc { get; set; } = null!;

    public string DiaChiNcc { get; set; } = null!;

    public string? KeLl { get; set; }

    public virtual ICollection<PhieuNhapHang> PhieuNhapHangs { get; set; } = new List<PhieuNhapHang>();

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
