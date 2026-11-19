using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("BinhLuan")]
public partial class BinhLuan
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("binhluanid")]
    public int? Binhluanid { get; set; }

    [Column("sanphamid")]
    public int Sanphamid { get; set; }

    [Column("nguoidang")]
    [StringLength(100)]
    public string Nguoidang { get; set; } = null!;

    [Column("sosao")]
    public int Sosao { get; set; }

    [Column("noidung")]
    public string Noidung { get; set; } = null!;

    [Column("ngaybinhluan")]
    public DateTime Ngaybinhluan { get; set; }

    [Column("kichhoat")]
    public bool Kichhoat { get; set; }

    [ForeignKey("Sanphamid")]
    [InverseProperty("BinhLuans")]
    public virtual SanPham Sanpham { get; set; } = null!;
}
