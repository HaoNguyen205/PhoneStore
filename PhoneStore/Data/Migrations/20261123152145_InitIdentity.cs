using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PhoneStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChiNhanh",
                columns: table => new
                {
                    chinhanhid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    khuvuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    tenchinhanh = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    diachi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    sodienthoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiNhanh__8C810A3013F0549A", x => x.chinhanhid);
                });

            migrationBuilder.CreateTable(
                name: "DanhMuc",
                columns: table => new
                {
                    danhmucid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tendanhmuc = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    icon = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    thutu = table.Column<int>(type: "int", nullable: false),
                    kichhoat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DanhMuc__BBADBA2503E6470C", x => x.danhmucid);
                });

            migrationBuilder.CreateTable(
                name: "HangSanXuat",
                columns: table => new
                {
                    hangid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tenhang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    logo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    thutu = table.Column<int>(type: "int", nullable: false),
                    kichhoat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__HangSanX__77BAD8694B4159A1", x => x.hangid);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    nguoidungid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tendangnhap = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    matkhau = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    hoten = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    sodienthoai = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    diachi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    hangthanhvien = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false, defaultValue: "Smember"),
                    diemthuong = table.Column<int>(type: "int", nullable: false),
                    vaitro = table.Column<int>(type: "int", nullable: false),
                    kichhoat = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NguoiDun__22456E556A8744FD", x => x.nguoidungid);
                });

            migrationBuilder.CreateTable(
                name: "NhuCau",
                columns: table => new
                {
                    nhucauid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tennhucau = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    thutu = table.Column<int>(type: "int", nullable: false),
                    kichhoat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NhuCau__F73498F9850D304E", x => x.nhucauid);
                });

            migrationBuilder.CreateTable(
                name: "TinCongNghe",
                columns: table => new
                {
                    tinid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tieude = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    tomtat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    noidung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hinhanh = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    nguoidang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ngaydang = table.Column<DateTime>(type: "datetime2", nullable: false),
                    luotxem = table.Column<int>(type: "int", nullable: false),
                    kichhoat = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TinCongN__E4A274C7D63C62CA", x => x.tinid);
                });

            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    donhangid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    madonhang = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    nguoidungid = table.Column<int>(type: "int", nullable: true),
                    chinhanhid = table.Column<int>(type: "int", nullable: true),
                    tennguoinhan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sdtnguoinhan = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    diachigiaohang = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    cothucudoimoi = table.Column<bool>(type: "bit", nullable: false),
                    maythucu = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    tientrogiathucu = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    giamgiathanhvien = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    tongtien = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    phuongthucthanhtoan = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    trangthai = table.Column<int>(type: "int", nullable: false),
                    ngaydat = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    ghichu = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DonHang__7E8E0BD3B6DB7782", x => x.donhangid);
                    table.ForeignKey(
                        name: "FK_donhang_chinhanh",
                        column: x => x.chinhanhid,
                        principalTable: "ChiNhanh",
                        principalColumn: "chinhanhid",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_donhang_nguoidung",
                        column: x => x.nguoidungid,
                        principalTable: "NguoiDung",
                        principalColumn: "nguoidungid",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "SanPham",
                columns: table => new
                {
                    sanphamid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    danhmucid = table.Column<int>(type: "int", nullable: false),
                    hangid = table.Column<int>(type: "int", nullable: false),
                    nhucauid = table.Column<int>(type: "int", nullable: true),
                    tensanpham = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    manhinh = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    chip = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ram = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    camera = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    pin = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    hedieuhanh = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    tomtat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mota = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hinhanh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    hotsale = table.Column<bool>(type: "bit", nullable: false),
                    tragop0 = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    trogiathucu = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    luotxem = table.Column<int>(type: "int", nullable: false),
                    noibat = table.Column<bool>(type: "bit", nullable: false),
                    kichhoat = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    ngaytao = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__SanPham__8EB3A43A154FEEF8", x => x.sanphamid);
                    table.ForeignKey(
                        name: "FK_sanpham_danhmuc",
                        column: x => x.danhmucid,
                        principalTable: "DanhMuc",
                        principalColumn: "danhmucid");
                    table.ForeignKey(
                        name: "FK_sanpham_hangsanxuat",
                        column: x => x.hangid,
                        principalTable: "HangSanXuat",
                        principalColumn: "hangid");
                    table.ForeignKey(
                        name: "FK_sanpham_nhucau",
                        column: x => x.nhucauid,
                        principalTable: "NhuCau",
                        principalColumn: "nhucauid");
                });

            migrationBuilder.CreateTable(
                name: "BienTheSanpham",
                columns: table => new
                {
                    bientheid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sanphamid = table.Column<int>(type: "int", nullable: false),
                    dungluong = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mausac = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    mamau = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    giaban = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    giakhuyenmai = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    soluongton = table.Column<int>(type: "int", nullable: false),
                    hinhanhbienthe = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    kichhoat = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BienTheS__C2F483718EA38D20", x => x.bientheid);
                    table.ForeignKey(
                        name: "FK_bienthe_sanpham",
                        column: x => x.sanphamid,
                        principalTable: "SanPham",
                        principalColumn: "sanphamid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BinhLuan",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    binhluanid = table.Column<int>(type: "int", nullable: true),
                    sanphamid = table.Column<int>(type: "int", nullable: false),
                    nguoidang = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    sosao = table.Column<int>(type: "int", nullable: false, defaultValue: 5),
                    noidung = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ngaybinhluan = table.Column<DateTime>(type: "datetime2", nullable: false),
                    kichhoat = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BinhLuan__3213E83F33BD98D4", x => x.id);
                    table.ForeignKey(
                        name: "FK_binhluan_sanpham",
                        column: x => x.sanphamid,
                        principalTable: "SanPham",
                        principalColumn: "sanphamid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KhuyenMaiSanPham",
                columns: table => new
                {
                    kmid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    sanphamid = table.Column<int>(type: "int", nullable: false),
                    noidungkm = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KhuyenMa__252A40CC02711271", x => x.kmid);
                    table.ForeignKey(
                        name: "FK_khuyenmai_sanpham",
                        column: x => x.sanphamid,
                        principalTable: "SanPham",
                        principalColumn: "sanphamid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChiTietDonHang",
                columns: table => new
                {
                    chitietid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donhangid = table.Column<int>(type: "int", nullable: false),
                    bientheid = table.Column<int>(type: "int", nullable: false),
                    soluong = table.Column<int>(type: "int", nullable: false),
                    dongia = table.Column<decimal>(type: "decimal(18,0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ChiTietD__B6A8B592E72C4E25", x => x.chitietid);
                    table.ForeignKey(
                        name: "FK_chitiet_bienthe",
                        column: x => x.bientheid,
                        principalTable: "BienTheSanpham",
                        principalColumn: "bientheid");
                    table.ForeignKey(
                        name: "FK_chitiet_donhang",
                        column: x => x.donhangid,
                        principalTable: "DonHang",
                        principalColumn: "donhangid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BienTheSanpham_sanphamid",
                table: "BienTheSanpham",
                column: "sanphamid");

            migrationBuilder.CreateIndex(
                name: "IX_BinhLuan_sanphamid",
                table: "BinhLuan",
                column: "sanphamid");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_bientheid",
                table: "ChiTietDonHang",
                column: "bientheid");

            migrationBuilder.CreateIndex(
                name: "IX_ChiTietDonHang_donhangid",
                table: "ChiTietDonHang",
                column: "donhangid");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_chinhanhid",
                table: "DonHang",
                column: "chinhanhid");

            migrationBuilder.CreateIndex(
                name: "IX_DonHang_nguoidungid",
                table: "DonHang",
                column: "nguoidungid");

            migrationBuilder.CreateIndex(
                name: "UQ__DonHang__74722A5E06110DBA",
                table: "DonHang",
                column: "madonhang",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KhuyenMaiSanPham_sanphamid",
                table: "KhuyenMaiSanPham",
                column: "sanphamid");

            migrationBuilder.CreateIndex(
                name: "UQ__NguoiDun__CE900A1EC33E805D",
                table: "NguoiDung",
                column: "tendangnhap",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_danhmucid",
                table: "SanPham",
                column: "danhmucid");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_hangid",
                table: "SanPham",
                column: "hangid");

            migrationBuilder.CreateIndex(
                name: "IX_SanPham_nhucauid",
                table: "SanPham",
                column: "nhucauid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BinhLuan");

            migrationBuilder.DropTable(
                name: "ChiTietDonHang");

            migrationBuilder.DropTable(
                name: "KhuyenMaiSanPham");

            migrationBuilder.DropTable(
                name: "TinCongNghe");

            migrationBuilder.DropTable(
                name: "BienTheSanpham");

            migrationBuilder.DropTable(
                name: "DonHang");

            migrationBuilder.DropTable(
                name: "SanPham");

            migrationBuilder.DropTable(
                name: "ChiNhanh");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "DanhMuc");

            migrationBuilder.DropTable(
                name: "HangSanXuat");

            migrationBuilder.DropTable(
                name: "NhuCau");
        }
    }
}
