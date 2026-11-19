using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("BienTheSanpham")]
public partial class BienTheSanpham
{
    [Key]
    [Column("bientheid")]
    public int Bientheid { get; set; }

    [Column("sanphamid")]
    public int Sanphamid { get; set; }

    [Column("dungluong")]
    [StringLength(50)]
    public string Dungluong { get; set; } = null!;

    [Column("mausac")]
    [StringLength(50)]
    public string Mausac { get; set; } = null!;

    [Column("mamau")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Mamau { get; set; }

    [Column("giaban", TypeName = "decimal(18, 0)")]
    public decimal Giaban { get; set; }

    [Column("giakhuyenmai", TypeName = "decimal(18, 0)")]
    public decimal? Giakhuyenmai { get; set; }

    [Column("soluongton")]
    public int Soluongton { get; set; }

    [Column("hinhanhbienthe")]
    [StringLength(255)]
    public string? Hinhanhbienthe { get; set; }

    [Column("kichhoat")]
    public bool Kichhoat { get; set; }

    [InverseProperty("Bienthe")]
    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    [ForeignKey("Sanphamid")]
    [InverseProperty("BienTheSanphams")]
    public virtual SanPham Sanpham { get; set; } = null!;
}
