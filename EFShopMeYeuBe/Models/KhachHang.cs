using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class KhachHang
{
    public int MaKh { get; set; }

    public string TenKh { get; set; } = null!;

    public DateTime Nskh { get; set; }

    public string? DiaChiKh { get; set; }

    public string? Sdtkh { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
