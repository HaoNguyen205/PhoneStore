using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("SanPham")]
public partial class SanPham
{
    [Key]
    [Column("sanphamid")]
    public int Sanphamid { get; set; }

    [Column("danhmucid")]
    public int Danhmucid { get; set; }

    [Column("hangid")]
    public int Hangid { get; set; }

    [Column("nhucauid")]
    public int? Nhucauid { get; set; }

    [Column("tensanpham")]
    [StringLength(255)]
    public string Tensanpham { get; set; } = null!;

    [Column("manhinh")]
    [StringLength(150)]
    public string? Manhinh { get; set; }

    [Column("chip")]
    [StringLength(100)]
    public string? Chip { get; set; }

    [Column("ram")]
    [StringLength(50)]
    public string? Ram { get; set; }

    [Column("camera")]
    [StringLength(150)]
    public string? Camera { get; set; }

    [Column("pin")]
    [StringLength(100)]
    public string? Pin { get; set; }

    [Column("hedieuhanh")]
    [StringLength(100)]
    public string? Hedieuhanh { get; set; }

    [Column("tomtat")]
    public string Tomtat { get; set; } = null!;

    [Column("mota")]
    public string Mota { get; set; } = null!;

    [Column("hinhanh")]
    public string? Hinhanh { get; set; }

    [Column("hotsale")]
    public bool Hotsale { get; set; }

    [Column("tragop0")]
    public bool Tragop0 { get; set; }

    [Column("trogiathucu", TypeName = "decimal(18, 0)")]
    public decimal Trogiathucu { get; set; }

    [Column("luotxem")]
    public int Luotxem { get; set; }

    [Column("noibat")]
    public bool Noibat { get; set; }

    [Column("kichhoat")]
    public bool Kichhoat { get; set; }

    [Column("ngaytao")]
    public DateTime Ngaytao { get; set; }

    [InverseProperty("Sanpham")]
    public virtual ICollection<BienTheSanpham> BienTheSanphams { get; set; } = new List<BienTheSanpham>();

    [InverseProperty("Sanpham")]
    public virtual ICollection<BinhLuan> BinhLuans { get; set; } = new List<BinhLuan>();

    [ForeignKey("Danhmucid")]
    [InverseProperty("SanPhams")]
    public virtual DanhMuc Danhmuc { get; set; } = null!;

    [ForeignKey("Hangid")]
    [InverseProperty("SanPhams")]
    public virtual HangSanXuat Hang { get; set; } = null!;

    [InverseProperty("Sanpham")]
    public virtual ICollection<KhuyenMaiSanPham> KhuyenMaiSanPhams { get; set; } = new List<KhuyenMaiSanPham>();

    [ForeignKey("Nhucauid")]
    [InverseProperty("SanPhams")]
    public virtual NhuCau? Nhucau { get; set; }
}
