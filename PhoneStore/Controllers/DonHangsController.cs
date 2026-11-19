using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneStore.Data;
using PhoneStore.Models;

namespace PhoneStore.Controllers
{
    public class DonHangsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonHangsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DonHangs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DonHangs.Include(d => d.Chinhanh).Include(d => d.Nguoidung);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DonHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.Chinhanh)
                .Include(d => d.Nguoidung)
                .FirstOrDefaultAsync(m => m.Donhangid == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // GET: DonHangs/Create
        public IActionResult Create()
        {
            ViewData["Chinhanhid"] = new SelectList(_context.ChiNhanhs, "Chinhanhid", "Chinhanhid");
            ViewData["Nguoidungid"] = new SelectList(_context.NguoiDungs, "Nguoidungid", "Nguoidungid");
            return View();
        }

        // POST: DonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Donhangid,Madonhang,Nguoidungid,Chinhanhid,Tennguoinhan,Sdtnguoinhan,Diachigiaohang,Cothucudoimoi,Maythucu,Tientrogiathucu,Giamgiathanhvien,Tongtien,Phuongthucthanhtoan,Trangthai,Ngaydat,Ghichu")] DonHang donHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(donHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Chinhanhid"] = new SelectList(_context.ChiNhanhs, "Chinhanhid", "Chinhanhid", donHang.Chinhanhid);
            ViewData["Nguoidungid"] = new SelectList(_context.NguoiDungs, "Nguoidungid", "Nguoidungid", donHang.Nguoidungid);
            return View(donHang);
        }

        // GET: DonHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang == null)
            {
                return NotFound();
            }
            ViewData["Chinhanhid"] = new SelectList(_context.ChiNhanhs, "Chinhanhid", "Chinhanhid", donHang.Chinhanhid);
            ViewData["Nguoidungid"] = new SelectList(_context.NguoiDungs, "Nguoidungid", "Nguoidungid", donHang.Nguoidungid);
            return View(donHang);
        }

        // POST: DonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Donhangid,Madonhang,Nguoidungid,Chinhanhid,Tennguoinhan,Sdtnguoinhan,Diachigiaohang,Cothucudoimoi,Maythucu,Tientrogiathucu,Giamgiathanhvien,Tongtien,Phuongthucthanhtoan,Trangthai,Ngaydat,Ghichu")] DonHang donHang)
        {
            if (id != donHang.Donhangid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(donHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DonHangExists(donHang.Donhangid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Chinhanhid"] = new SelectList(_context.ChiNhanhs, "Chinhanhid", "Chinhanhid", donHang.Chinhanhid);
            ViewData["Nguoidungid"] = new SelectList(_context.NguoiDungs, "Nguoidungid", "Nguoidungid", donHang.Nguoidungid);
            return View(donHang);
        }

        // GET: DonHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var donHang = await _context.DonHangs
                .Include(d => d.Chinhanh)
                .Include(d => d.Nguoidung)
                .FirstOrDefaultAsync(m => m.Donhangid == id);
            if (donHang == null)
            {
                return NotFound();
            }

            return View(donHang);
        }

        // POST: DonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var donHang = await _context.DonHangs.FindAsync(id);
            if (donHang != null)
            {
                _context.DonHangs.Remove(donHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DonHangExists(int id)
        {
            return _context.DonHangs.Any(e => e.Donhangid == id);
        }
    }
}
