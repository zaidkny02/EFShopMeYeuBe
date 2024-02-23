using System;
using System.Collections.Generic;

namespace EFShopMeYeuBe.Models;

public partial class NhanVien
{
    public int MaNv { get; set; }

    public string TenNv { get; set; } = null!;

    public DateTime Nsnv { get; set; }

    public string? Gt { get; set; }

    public string? DiaChiNv { get; set; }

    public string? Sdtnv { get; set; }

    public double? Hsluong { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<MaGiamGium> MaGiamGia { get; set; } = new List<MaGiamGium>();

    public virtual ICollection<PhieuNhapHang> PhieuNhapHangs { get; set; } = new List<PhieuNhapHang>();
}
