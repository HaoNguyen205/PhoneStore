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
    public class KhuyenMaiSanPhamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KhuyenMaiSanPhamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KhuyenMaiSanPhams
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KhuyenMaiSanPhams.Include(k => k.Sanpham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KhuyenMaiSanPhams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMaiSanPham = await _context.KhuyenMaiSanPhams
                .Include(k => k.Sanpham)
                .FirstOrDefaultAsync(m => m.Kmid == id);
            if (khuyenMaiSanPham == null)
            {
                return NotFound();
            }

            return View(khuyenMaiSanPham);
        }

        // GET: KhuyenMaiSanPhams/Create
        public IActionResult Create()
        {
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid");
            return View();
        }

        // POST: KhuyenMaiSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Kmid,Sanphamid,Noidungkm")] KhuyenMaiSanPham khuyenMaiSanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khuyenMaiSanPham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid", khuyenMaiSanPham.Sanphamid);
            return View(khuyenMaiSanPham);
        }

        // GET: KhuyenMaiSanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMaiSanPham = await _context.KhuyenMaiSanPhams.FindAsync(id);
            if (khuyenMaiSanPham == null)
            {
                return NotFound();
            }
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid", khuyenMaiSanPham.Sanphamid);
            return View(khuyenMaiSanPham);
        }

        // POST: KhuyenMaiSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Kmid,Sanphamid,Noidungkm")] KhuyenMaiSanPham khuyenMaiSanPham)
        {
            if (id != khuyenMaiSanPham.Kmid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khuyenMaiSanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhuyenMaiSanPhamExists(khuyenMaiSanPham.Kmid))
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
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid", khuyenMaiSanPham.Sanphamid);
            return View(khuyenMaiSanPham);
        }

        // GET: KhuyenMaiSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var khuyenMaiSanPham = await _context.KhuyenMaiSanPhams
                .Include(k => k.Sanpham)
                .FirstOrDefaultAsync(m => m.Kmid == id);
            if (khuyenMaiSanPham == null)
            {
                return NotFound();
            }

            return View(khuyenMaiSanPham);
        }

        // POST: KhuyenMaiSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var khuyenMaiSanPham = await _context.KhuyenMaiSanPhams.FindAsync(id);
            if (khuyenMaiSanPham != null)
            {
                _context.KhuyenMaiSanPhams.Remove(khuyenMaiSanPham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhuyenMaiSanPhamExists(int id)
        {
            return _context.KhuyenMaiSanPhams.Any(e => e.Kmid == id);
        }
    }
}
