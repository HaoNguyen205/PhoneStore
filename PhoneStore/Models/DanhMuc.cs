using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("DanhMuc")]
public partial class DanhMuc
{
    [Key]
    [Column("danhmucid")]
    public int Danhmucid { get; set; }

    [Column("tendanhmuc")]
    [StringLength(100)]
    public string Tendanhmuc { get; set; } = null!;

    [Column("icon")]
    [StringLength(100)]
    public string? Icon { get; set; }

    [Column("thutu")]
    public int Thutu { get; set; }

    [Column("kichhoat")]
    public bool Kichhoat { get; set; }

    [InverseProperty("Danhmuc")]
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
