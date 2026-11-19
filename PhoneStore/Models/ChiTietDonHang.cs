using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("ChiTietDonHang")]
public partial class ChiTietDonHang
{
    [Key]
    [Column("chitietid")]
    public int Chitietid { get; set; }

    [Column("donhangid")]
    public int Donhangid { get; set; }

    [Column("bientheid")]
    public int Bientheid { get; set; }

    [Column("soluong")]
    public int Soluong { get; set; }

    [Column("dongia", TypeName = "decimal(18, 0)")]
    public decimal Dongia { get; set; }

    [ForeignKey("Bientheid")]
    [InverseProperty("ChiTietDonHangs")]
    public virtual BienTheSanpham Bienthe { get; set; } = null!;

    [ForeignKey("Donhangid")]
    [InverseProperty("ChiTietDonHangs")]
    public virtual DonHang Donhang { get; set; } = null!;
}
