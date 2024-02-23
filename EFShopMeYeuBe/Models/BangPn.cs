using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class BangPn
{
    public int MaPhieu { get; set; }

    public string TênNhânViên { get; set; } = null!;

    public DateTime NgayLap { get; set; }

    public string TenNcc { get; set; } = null!;

    public double? TongTienNhap { get; set; }
}
