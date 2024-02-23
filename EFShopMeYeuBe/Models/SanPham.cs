using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFShopMeYeuBe.Models;

public partial class SanPham
{
    public int MaSp { get; set; }

    public string TenSp { get; set; } = null!;

    public bool? Trangthaikinhdoanh { get; set; }

    public string? Mota { get; set; }

    public double Dongia { get; set; }

    public int MaNcc { get; set; }

    public int MaHang { get; set; }

    public int MaLoaiSp { get; set; }

    

    public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; } = new List<ChiTietSanPham>();

    public virtual ICollection<MaGiamGium> MaGiamGia { get; set; } = new List<MaGiamGium>();
#nullable disable 
    public virtual Hang MaHangNavigation { get; set; } = null!;
#nullable disable 
    public virtual LoaiSanPham MaLoaiSpNavigation { get; set; } = null!;
#nullable disable 
    public virtual NhaCungCap MaNccNavigation { get; set; } = null!;
}
