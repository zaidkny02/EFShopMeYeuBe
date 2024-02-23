using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class BangHd
{
    public int MaHoAĐơn { get; set; }

    public string TênNhânViên { get; set; } = null!;

    public DateTime NgaYLâP { get; set; }

    public string TênKhaChHaNg { get; set; } = null!;
}
