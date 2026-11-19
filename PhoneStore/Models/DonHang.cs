using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("DonHang")]
[Index("Madonhang", Name = "UQ__DonHang__74722A5E06110DBA", IsUnique = true)]
public partial class DonHang
{
    [Key]
    [Column("donhangid")]
    public int Donhangid { get; set; }

    [Column("madonhang")]
    [StringLength(20)]
    [Unicode(false)]
    public string Madonhang { get; set; } = null!;

    [Column("nguoidungid")]
    public int? Nguoidungid { get; set; }

    [Column("chinhanhid")]
    public int? Chinhanhid { get; set; }

    [Column("tennguoinhan")]
    [StringLength(100)]
    public string Tennguoinhan { get; set; } = null!;

    [Column("sdtnguoinhan")]
    [StringLength(20)]
    public string Sdtnguoinhan { get; set; } = null!;

    [Column("diachigiaohang")]
    [StringLength(255)]
    public string Diachigiaohang { get; set; } = null!;

    [Column("cothucudoimoi")]
    public bool Cothucudoimoi { get; set; }

    [Column("maythucu")]
    [StringLength(150)]
    public string? Maythucu { get; set; }

    [Column("tientrogiathucu", TypeName = "decimal(18, 0)")]
    public decimal Tientrogiathucu { get; set; }

    [Column("giamgiathanhvien", TypeName = "decimal(18, 0)")]
    public decimal Giamgiathanhvien { get; set; }

    [Column("tongtien", TypeName = "decimal(18, 0)")]
    public decimal Tongtien { get; set; }

    [Column("phuongthucthanhtoan")]
    [StringLength(100)]
    public string Phuongthucthanhtoan { get; set; } = null!;

    [Column("trangthai")]
    public int Trangthai { get; set; }

    [Column("ngaydat")]
    public DateTime Ngaydat { get; set; }

    [Column("ghichu")]
    public string? Ghichu { get; set; }

    [InverseProperty("Donhang")]
    public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; } = new List<ChiTietDonHang>();

    [ForeignKey("Chinhanhid")]
    [InverseProperty("DonHangs")]
    public virtual ChiNhanh? Chinhanh { get; set; }

    [ForeignKey("Nguoidungid")]
    [InverseProperty("DonHangs")]
    public virtual NguoiDung? Nguoidung { get; set; }
}
