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
    public class BinhLuansController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BinhLuansController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BinhLuans
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BinhLuans.Include(b => b.Sanpham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BinhLuans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuans
                .Include(b => b.Sanpham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (binhLuan == null)
            {
                return NotFound();
            }

            return View(binhLuan);
        }

        // GET: BinhLuans/Create
        public IActionResult Create()
        {
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid");
            return View();
        }

        // POST: BinhLuans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Binhluanid,Sanphamid,Nguoidang,Sosao,Noidung,Ngaybinhluan,Kichhoat")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(binhLuan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid", binhLuan.Sanphamid);
            return View(binhLuan);
        }

        // GET: BinhLuans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuans.FindAsync(id);
            if (binhLuan == null)
            {
                return NotFound();
            }
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid", binhLuan.Sanphamid);
            return View(binhLuan);
        }

        // POST: BinhLuans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Binhluanid,Sanphamid,Nguoidang,Sosao,Noidung,Ngaybinhluan,Kichhoat")] BinhLuan binhLuan)
        {
            if (id != binhLuan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(binhLuan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BinhLuanExists(binhLuan.Id))
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
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid", binhLuan.Sanphamid);
            return View(binhLuan);
        }

        // GET: BinhLuans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var binhLuan = await _context.BinhLuans
                .Include(b => b.Sanpham)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (binhLuan == null)
            {
                return NotFound();
            }

            return View(binhLuan);
        }

        // POST: BinhLuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var binhLuan = await _context.BinhLuans.FindAsync(id);
            if (binhLuan != null)
            {
                _context.BinhLuans.Remove(binhLuan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BinhLuanExists(int id)
        {
            return _context.BinhLuans.Any(e => e.Id == id);
        }
    }
}
