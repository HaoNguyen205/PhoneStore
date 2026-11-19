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
    public class ChiTietDonHangsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChiTietDonHangsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChiTietDonHangs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ChiTietDonHangs.Include(c => c.Bienthe).Include(c => c.Donhang);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ChiTietDonHangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDonHang = await _context.ChiTietDonHangs
                .Include(c => c.Bienthe)
                .Include(c => c.Donhang)
                .FirstOrDefaultAsync(m => m.Chitietid == id);
            if (chiTietDonHang == null)
            {
                return NotFound();
            }

            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHangs/Create
        public IActionResult Create()
        {
            ViewData["Bientheid"] = new SelectList(_context.BienTheSanphams, "Bientheid", "Bientheid");
            ViewData["Donhangid"] = new SelectList(_context.DonHangs, "Donhangid", "Donhangid");
            return View();
        }

        // POST: ChiTietDonHangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Chitietid,Donhangid,Bientheid,Soluong,Dongia")] ChiTietDonHang chiTietDonHang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiTietDonHang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Bientheid"] = new SelectList(_context.BienTheSanphams, "Bientheid", "Bientheid", chiTietDonHang.Bientheid);
            ViewData["Donhangid"] = new SelectList(_context.DonHangs, "Donhangid", "Donhangid", chiTietDonHang.Donhangid);
            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDonHang = await _context.ChiTietDonHangs.FindAsync(id);
            if (chiTietDonHang == null)
            {
                return NotFound();
            }
            ViewData["Bientheid"] = new SelectList(_context.BienTheSanphams, "Bientheid", "Bientheid", chiTietDonHang.Bientheid);
            ViewData["Donhangid"] = new SelectList(_context.DonHangs, "Donhangid", "Donhangid", chiTietDonHang.Donhangid);
            return View(chiTietDonHang);
        }

        // POST: ChiTietDonHangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Chitietid,Donhangid,Bientheid,Soluong,Dongia")] ChiTietDonHang chiTietDonHang)
        {
            if (id != chiTietDonHang.Chitietid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietDonHang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietDonHangExists(chiTietDonHang.Chitietid))
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
            ViewData["Bientheid"] = new SelectList(_context.BienTheSanphams, "Bientheid", "Bientheid", chiTietDonHang.Bientheid);
            ViewData["Donhangid"] = new SelectList(_context.DonHangs, "Donhangid", "Donhangid", chiTietDonHang.Donhangid);
            return View(chiTietDonHang);
        }

        // GET: ChiTietDonHangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiTietDonHang = await _context.ChiTietDonHangs
                .Include(c => c.Bienthe)
                .Include(c => c.Donhang)
                .FirstOrDefaultAsync(m => m.Chitietid == id);
            if (chiTietDonHang == null)
            {
                return NotFound();
            }

            return View(chiTietDonHang);
        }

        // POST: ChiTietDonHangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiTietDonHang = await _context.ChiTietDonHangs.FindAsync(id);
            if (chiTietDonHang != null)
            {
                _context.ChiTietDonHangs.Remove(chiTietDonHang);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietDonHangExists(int id)
        {
            return _context.ChiTietDonHangs.Any(e => e.Chitietid == id);
        }
    }
}
