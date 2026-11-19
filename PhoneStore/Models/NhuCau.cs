using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("NhuCau")]
public partial class NhuCau
{
    [Key]
    [Column("nhucauid")]
    public int Nhucauid { get; set; }

    [Column("tennhucau")]
    [StringLength(100)]
    public string Tennhucau { get; set; } = null!;

    [Column("thutu")]
    public int Thutu { get; set; }

    [Column("kichhoat")]
    public bool Kichhoat { get; set; }

    [InverseProperty("Nhucau")]
    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
