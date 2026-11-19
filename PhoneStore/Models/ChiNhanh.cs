using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("ChiNhanh")]
public partial class ChiNhanh
{
    [Key]
    [Column("chinhanhid")]
    public int Chinhanhid { get; set; }

    [Column("khuvuc")]
    [StringLength(100)]
    public string Khuvuc { get; set; } = null!;

    [Column("tenchinhanh")]
    [StringLength(200)]
    public string Tenchinhanh { get; set; } = null!;

    [Column("diachi")]
    [StringLength(255)]
    public string Diachi { get; set; } = null!;

    [Column("sodienthoai")]
    [StringLength(20)]
    public string Sodienthoai { get; set; } = null!;

    [InverseProperty("Chinhanh")]
    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
