using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PhoneStore.Models;

[Table("NguoiDung")]
[Index("Tendangnhap", Name = "UQ__NguoiDun__CE900A1EC33E805D", IsUnique = true)]
public partial class NguoiDung
{
    [Key]
    [Column("nguoidungid")]
    public int Nguoidungid { get; set; }

    [Column("tendangnhap")]
    [StringLength(50)]
    public string Tendangnhap { get; set; } = null!;

    [Column("matkhau")]
    [StringLength(255)]
    public string Matkhau { get; set; } = null!;

    [Column("hoten")]
    [StringLength(100)]
    public string Hoten { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string? Email { get; set; }

    [Column("sodienthoai")]
    [StringLength(20)]
    public string? Sodienthoai { get; set; }

    [Column("diachi")]
    [StringLength(255)]
    public string? Diachi { get; set; }

    [Column("hangthanhvien")]
    [StringLength(30)]
    public string Hangthanhvien { get; set; } = null!;

    [Column("diemthuong")]
    public int Diemthuong { get; set; }

    [Column("vaitro")]
    public int Vaitro { get; set; }

    [Column("kichhoat")]
    public bool Kichhoat { get; set; }

    [InverseProperty("Nguoidung")]
    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();
}
