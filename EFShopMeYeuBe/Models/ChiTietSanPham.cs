using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFShopMeYeuBe.Models;
public partial class ChiTietSanPham
{
    public int MaSp { get; set; }
    [Required]
    public string Size { get; set; } = null!;

    public int SoLuongTheoSize { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();
#nullable disable

    public virtual SanPham MaSpNavigation { get; set; } = null!;
}
