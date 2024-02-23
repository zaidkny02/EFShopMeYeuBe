using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class HoaDon
{
    public int MaHd { get; set; }

    public DateTime NgayLapHd { get; set; }

    public int MaNv { get; set; }

    public int MaKh { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
#nullable disable

    public virtual KhachHang MaKhNavigation { get; set; } = null!;
#nullable disable

    public virtual NhanVien MaNvNavigation { get; set; } = null!;
}
