using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFShopMeYeuBe.Models;

public partial class CdnShopMeYeuBeContext : DbContext
{
    public CdnShopMeYeuBeContext()
    {
    }

    public CdnShopMeYeuBeContext(DbContextOptions<CdnShopMeYeuBeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BangHd> BangHds { get; set; }

    public virtual DbSet<BangPn> BangPns { get; set; }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

    public virtual DbSet<ChiTietSanPham> ChiTietSanPhams { get; set; }

    public virtual DbSet<DsHoaDon> DsHoaDons { get; set; }

    public virtual DbSet<Hang> Hangs { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiSanPham> LoaiSanPhams { get; set; }

    public virtual DbSet<MaGiamGium> MaGiamGia { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhieuNhapHang> PhieuNhapHangs { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<SoluongSp> SoluongSps { get; set; }

    public virtual DbSet<SoluongcacSp> SoluongcacSps { get; set; }

    public virtual DbSet<SpConban> SpConbans { get; set; }

    public virtual DbSet<SpHangLoaiSp> SpHangLoaiSps { get; set; }

    public virtual DbSet<SpKhongbanduoc> SpKhongbanduocs { get; set; }

    public virtual DbSet<TongTienKh> TongTienKhs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BangHd>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BangHD");

            entity.Property(e => e.MaHoAĐơn).HasColumnName("Mã hóa đơn");
            entity.Property(e => e.NgaYLâP)
                .HasColumnType("datetime")
                .HasColumnName("Ngày lập");
            entity.Property(e => e.TênKhaChHaNg)
                .HasMaxLength(20)
                .HasColumnName("Tên khách hàng");
            entity.Property(e => e.TênNhânViên)
                .HasMaxLength(50)
                .HasColumnName("Tên nhân viên");
        });

        modelBuilder.Entity<BangPn>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BangPN");

            entity.Property(e => e.MaPhieu).HasColumnName("Ma phieu");
            entity.Property(e => e.NgayLap)
                .HasColumnType("datetime")
                .HasColumnName("Ngay Lap");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(20)
                .HasColumnName("Ten NCC");
            entity.Property(e => e.TongTienNhap).HasColumnName("Tong Tien Nhap");
            entity.Property(e => e.TênNhânViên)
                .HasMaxLength(50)
                .HasColumnName("Tên nhân viên");
        });

        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHd, e.MaSp, e.Size }).HasName("PK__ChiTietH__F3F4D36C6647F866");

            entity.ToTable("ChiTietHoaDon", tb =>
                {
                    tb.HasTrigger("TrigChiTietHoaDon");
                    tb.HasTrigger("TrigDelChiTietHoaDon");
                });

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.Size).HasMaxLength(5);
            entity.Property(e => e.SoLban).HasColumnName("SoLBan");

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHd)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHoa__MaHD__24927208");

            entity.HasOne(d => d.ChiTietSanPham).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => new {  d.MaSp, d.Size })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHoaDon__25869641");
        });

        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
        {
            entity.HasKey(e => new { e.MaP, e.MaSp, e.Size }).HasName("PK__ChiTietP__13460E2489E8F904");

            entity.ToTable("ChiTietPhieuNhap", tb => tb.HasTrigger("TrigChiTietNhap"));

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.Size).HasMaxLength(5);
            entity.Property(e => e.SoLnhap).HasColumnName("SoLNhap");

            entity.HasOne(d => d.MaPNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaP)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPhie__MaP__49C3F6B7");

            entity.HasOne(d => d.ChiTietSanPham).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => new { d.MaSp, d.Size })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPhieuNhap__4AB81AF0");
        });

        modelBuilder.Entity<ChiTietSanPham>(entity =>
        {
            entity.HasKey(e => new { e.MaSp, e.Size }).HasName("PK__ChiTietS__4D1758CC67069071");

            entity.ToTable("ChiTietSanPham", tb => tb.HasTrigger("UTRIGG_CNTT"));

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.Size).HasMaxLength(5);

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.ChiTietSanPhams)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietSan__MaSP__21B6055D");
        });

        modelBuilder.Entity<DsHoaDon>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DS_HoaDon");

            entity.Property(e => e.MaHoAĐơn).HasColumnName("Mã hóa đơn");
            entity.Property(e => e.NgaYLâP)
                .HasColumnType("datetime")
                .HasColumnName("Ngày lập");
            entity.Property(e => e.ThaNhTiêN).HasColumnName("Thành tiền");
            entity.Property(e => e.TênKhaChHaNg)
                .HasMaxLength(20)
                .HasColumnName("Tên khách hàng");
            entity.Property(e => e.TênNhânViên)
                .HasMaxLength(50)
                .HasColumnName("Tên nhân viên");
        });

        modelBuilder.Entity<Hang>(entity =>
        {
            entity.HasKey(e => e.MaHang).HasName("PK__Hang__19C0DB1D91853F7F");

            entity.ToTable("Hang");

            entity.Property(e => e.TenHang).HasMaxLength(20);
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK__HoaDon__2725A6E04BE81462");

            entity.ToTable("HoaDon", tb => tb.HasTrigger("TrigDelHoaDon"));

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayLapHd)
                .HasColumnType("datetime")
                .HasColumnName("NgayLapHD");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDon__MaKH__2E1BDC42");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDon__MaNV__2D27B809");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK__KhachHan__2725CF1E1184C71C");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh).HasColumnName("MaKH");
            entity.Property(e => e.DiaChiKh)
                .HasMaxLength(50)
                .HasColumnName("DiaChiKH");
            entity.Property(e => e.Nskh)
                .HasColumnType("date")
                .HasColumnName("NSKH");
            entity.Property(e => e.Sdtkh)
                .HasMaxLength(11)
                .HasColumnName("SDTKH");
            entity.Property(e => e.TenKh)
                .HasMaxLength(20)
                .HasColumnName("TenKH");
        });

        modelBuilder.Entity<LoaiSanPham>(entity =>
        {
            entity.HasKey(e => e.MaLoaiSp).HasName("PK__LoaiSanP__1224CA7CBBAC7D17");

            entity.ToTable("LoaiSanPham");

            entity.Property(e => e.MaLoaiSp).HasColumnName("MaLoaiSP");
            entity.Property(e => e.TenLsp)
                .HasMaxLength(20)
                .HasColumnName("TenLSP");
        });

        modelBuilder.Entity<MaGiamGium>(entity =>
        {
            entity.HasKey(e => e.MaGiamGia).HasName("PK__MaGiamGi__EF9458E4BB7464C4");

            entity.Property(e => e.GiatriKm).HasColumnName("GiatriKM");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.MaSp).HasColumnName("MaSP");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.MaGiamGia)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MaGiamGia__MaNV__30F848ED");

            entity.HasOne(d => d.MaSpNavigation).WithMany(p => p.MaGiamGia)
                .HasForeignKey(d => d.MaSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MaGiamGia__MaSP__31EC6D26");
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK__NhaCungC__3A185DEBEB32280E");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.DiaChiNcc)
                .HasMaxLength(50)
                .HasColumnName("DiaChiNCC");
            entity.Property(e => e.KeLl)
                .HasMaxLength(50)
                .HasColumnName("KeLL");
            entity.Property(e => e.Sdtncc)
                .HasMaxLength(11)
                .HasColumnName("SDTNCC");
            entity.Property(e => e.TenNcc)
                .HasMaxLength(20)
                .HasColumnName("TenNCC");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv).HasName("PK__NhanVien__2725D70AB19BF399");

            entity.ToTable("NhanVien", tb => tb.HasTrigger("KTTuoiNV"));

            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.DiaChiNv)
                .HasMaxLength(50)
                .HasColumnName("DiaChiNV");
            entity.Property(e => e.Gt)
                .HasMaxLength(50)
                .HasColumnName("GT");
            entity.Property(e => e.Hsluong).HasColumnName("HSLuong");
            entity.Property(e => e.Nsnv)
                .HasColumnType("date")
                .HasColumnName("NSNV");
            entity.Property(e => e.Sdtnv)
                .HasMaxLength(11)
                .HasColumnName("SDTNV");
            entity.Property(e => e.TenNv)
                .HasMaxLength(50)
                .HasColumnName("TenNV");
        });

        modelBuilder.Entity<PhieuNhapHang>(entity =>
        {
            entity.HasKey(e => e.MaP).HasName("PK__PhieuNha__C7977BA82D7CE63F");

            entity.ToTable("PhieuNhapHang", tb => tb.HasTrigger("TrigDelPhieuNhap"));

            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.MaNv).HasColumnName("MaNV");
            entity.Property(e => e.NgayLapPhieu).HasColumnType("datetime");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.PhieuNhapHangs)
                .HasForeignKey(d => d.MaNcc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuNhap__MaNCC__300424B4");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhieuNhapHangs)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PhieuNhapH__MaNV__2F10007B");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.MaSp).HasName("PK__SanPham__2725081CA3205B5F");

            entity.ToTable("SanPham");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.MaLoaiSp).HasColumnName("MaLoaiSP");
            entity.Property(e => e.MaNcc).HasColumnName("MaNCC");
            entity.Property(e => e.Mota).HasMaxLength(100);
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .HasColumnName("TenSP");

            entity.HasOne(d => d.MaHangNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SanPham__MaHang__2B3F6F97");

            entity.HasOne(d => d.MaLoaiSpNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaLoaiSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SanPham__MaLoaiS__2C3393D0");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.MaNcc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SanPham__MaNCC__2A4B4B5E");
        });

        modelBuilder.Entity<SoluongSp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SoluongSP");

            entity.Property(e => e.Size).HasMaxLength(5);
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .HasColumnName("TenSP");
        });

        modelBuilder.Entity<SoluongcacSp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SoluongcacSP");

            entity.Property(e => e.MaSaNPhâM).HasColumnName("Mã sản phẩm");
            entity.Property(e => e.SôLươNg).HasColumnName("Số lượng");
            entity.Property(e => e.TênSaNPhâM)
                .HasMaxLength(50)
                .HasColumnName("Tên sản phẩm");
        });

        modelBuilder.Entity<SpConban>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SP_Conban");

            entity.Property(e => e.MaSp)
                .ValueGeneratedOnAdd()
                .HasColumnName("MaSP");
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .HasColumnName("TenSP");
        });

        modelBuilder.Entity<SpHangLoaiSp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SP_Hang_LoaiSP");

            entity.Property(e => e.LoaI)
                .HasMaxLength(20)
                .HasColumnName("Loại ");
            entity.Property(e => e.MaSaNPhâM).HasColumnName("Mã sản phẩm");
            entity.Property(e => e.TênHaNg)
                .HasMaxLength(20)
                .HasColumnName("Tên Hãng");
            entity.Property(e => e.TênSaNPhâM)
                .HasMaxLength(50)
                .HasColumnName("Tên sản phẩm");
        });

        modelBuilder.Entity<SpKhongbanduoc>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SP_Khongbanduoc");

            entity.Property(e => e.MaSp).HasColumnName("MaSP");
            entity.Property(e => e.TenSp)
                .HasMaxLength(50)
                .HasColumnName("TenSP");
        });

        modelBuilder.Entity<TongTienKh>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("TongTien_KH");

            entity.Property(e => e.TênKhaChHaNg)
                .HasMaxLength(20)
                .HasColumnName("Tên khách hàng");
            entity.Property(e => e.TôNgTiêN).HasColumnName("Tổng tiền");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
