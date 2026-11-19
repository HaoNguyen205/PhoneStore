using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("KhuyenMaiSanPham")]
public partial class KhuyenMaiSanPham
{
    [Key]
    [Column("kmid")]
    public int Kmid { get; set; }

    [Column("sanphamid")]
    public int Sanphamid { get; set; }

    [Column("noidungkm")]
    [StringLength(500)]
    public string Noidungkm { get; set; } = null!;

    [ForeignKey("Sanphamid")]
    [InverseProperty("KhuyenMaiSanPhams")]
    public virtual SanPham Sanpham { get; set; } = null!;
}
