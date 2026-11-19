using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("HangSanXuat")]
public partial class HangSanXuat
{
    [Key]
    [Column("hangid")]
    public int Hangid { get; set; }

    [Column("tenhang")]
    [StringLength(100)]
    public string Tenhang { get; set; } = null!;

    [Column("logo")]
    [StringLength(255)]
    public string? Logo { get; set; }

    [Column("thutu")]
    public int Thutu { get; set; }

    [Column("kichhoat")]
    public bool Kichhoat { get; set; }

    [InverseProperty("Hang")]
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
