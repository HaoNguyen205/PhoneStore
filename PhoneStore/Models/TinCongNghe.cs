using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("TinCongNghe")]
public partial class TinCongNghe
{
    [Key]
    [Column("tinid")]
    public int Tinid { get; set; }

    [Column("tieude")]
    [StringLength(255)]
    public string Tieude { get; set; } = null!;

    [Column("tomtat")]
    public string Tomtat { get; set; } = null!;

    [Column("noidung")]
    public string Noidung { get; set; } = null!;

    [Column("hinhanh")]
    [StringLength(255)]
    public string? Hinhanh { get; set; }

    [Column("nguoidang")]
    [StringLength(100)]
    public string Nguoidang { get; set; } = null!;

    [Column("ngaydang")]
    public DateTime Ngaydang { get; set; }

    [Column("luotxem")]
    public int Luotxem { get; set; }

    [Column("kichhoat")]
    public bool Kichhoat { get; set; }
}
