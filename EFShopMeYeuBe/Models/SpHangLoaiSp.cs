using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class SpHangLoaiSp
{
    public int MaSaNPhâM { get; set; }

    public string TênSaNPhâM { get; set; } = null!;

    public string LoaI { get; set; } = null!;

    public string TênHaNg { get; set; } = null!;
}
