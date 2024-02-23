using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class PhieuNhapHang
{
    public int MaP { get; set; }

    public DateTime NgayLapPhieu { get; set; }

    public int MaNv { get; set; }

    public int MaNcc { get; set; }

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual NhaCungCap MaNccNavigation { get; set; } = null!;

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
