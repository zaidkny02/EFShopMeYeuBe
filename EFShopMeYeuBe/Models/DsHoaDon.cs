using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class DsHoaDon
{
    public int MaHoAĐơn { get; set; }

    public DateTime NgaYLâP { get; set; }

    public string TênNhânViên { get; set; } = null!;

    public string TênKhaChHaNg { get; set; } = null!;

    public double? ThaNhTiêN { get; set; }
}
