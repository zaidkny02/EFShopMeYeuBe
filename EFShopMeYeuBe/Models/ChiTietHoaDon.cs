using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class ChiTietHoaDon
{
    public int MaHd { get; set; }

    public int MaSp { get; set; }

    public int SoLban { get; set; }

    public string Size { get; set; } = null!;
#nullable disable

    public virtual ChiTietSanPham ChiTietSanPham { get; set; } = null!;
#nullable disable

    public virtual HoaDon MaHdNavigation { get; set; } = null!;
}
