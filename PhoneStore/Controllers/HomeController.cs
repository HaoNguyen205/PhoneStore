using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Data;
using PhoneStore.Data;

namespace PhoneStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? hangId, int? nhucauId)
        {
            // Lấy danh sách Hãng & Nhu cầu cho thanh lọc
            ViewBag.DanhSachHang = await _context.HangSanXuats
                .Where(h => h.Kichhoat)
                .OrderBy(h => h.Thutu)
                .ToListAsync();

            ViewBag.DanhSachNhuCau = await _context.NhuCaus
                .Where(n => n.Kichhoat)
                .OrderBy(n => n.Thutu)
                .ToListAsync();

            // Lấy danh sách sản phẩm Hot Sale Cuối Tuần
            ViewBag.SanPhamHotSale = await _context.SanPhams
                .Include(s => s.BienTheSanphams)
                .Include(s => s.Hang)
                .Where(s => s.Kichhoat && s.Hotsale)
                .OrderByDescending(s => s.Ngaytao)
                .Take(5)
                .ToListAsync();

            // Truy vấn danh sách Điện thoại nổi bật (có lọc theo Hãng hoặc Nhu cầu)
            var querySanPham = _context.SanPhams
                .Include(s => s.BienTheSanphams)
                .Include(s => s.Hang)
                .Where(s => s.Kichhoat);

            if (hangId.HasValue)
            {
                querySanPham = querySanPham.Where(s => s.Hangid == hangId.Value);
                ViewBag.HangDangChon = hangId.Value;
            }

            if (nhucauId.HasValue)
            {
                querySanPham = querySanPham.Where(s => s.Nhucauid == nhucauId.Value);
                ViewBag.NhuCauDangChon = nhucauId.Value;
            }

            var danhSachSanPham = await querySanPham
                .OrderByDescending(s => s.Noibat)
                .ThenByDescending(s => s.Luotxem)
                .ToListAsync();

            // Lấy Tin công nghệ Sforum
            ViewBag.TinCongNghe = await _context.TinCongNghes
                .Where(t => t.Kichhoat)
                .OrderByDescending(t => t.Ngaydang)
                .Take(4)
                .ToListAsync();

            return View(danhSachSanPham);
        }
    }
}