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
    public class BienTheSanphamsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BienTheSanphamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BienTheSanphams
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BienTheSanphams.Include(b => b.Sanpham);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BienTheSanphams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienTheSanpham = await _context.BienTheSanphams
                .Include(b => b.Sanpham)
                .FirstOrDefaultAsync(m => m.Bientheid == id);
            if (bienTheSanpham == null)
            {
                return NotFound();
            }

            return View(bienTheSanpham);
        }

        // GET: BienTheSanphams/Create
        public IActionResult Create()
        {
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid");
            return View();
        }

        // POST: BienTheSanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bientheid,Sanphamid,Dungluong,Mausac,Mamau,Giaban,Giakhuyenmai,Soluongton,Hinhanhbienthe,Kichhoat")] BienTheSanpham bienTheSanpham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bienTheSanpham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid", bienTheSanpham.Sanphamid);
            return View(bienTheSanpham);
        }

        // GET: BienTheSanphams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienTheSanpham = await _context.BienTheSanphams.FindAsync(id);
            if (bienTheSanpham == null)
            {
                return NotFound();
            }
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid", bienTheSanpham.Sanphamid);
            return View(bienTheSanpham);
        }

        // POST: BienTheSanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Bientheid,Sanphamid,Dungluong,Mausac,Mamau,Giaban,Giakhuyenmai,Soluongton,Hinhanhbienthe,Kichhoat")] BienTheSanpham bienTheSanpham)
        {
            if (id != bienTheSanpham.Bientheid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bienTheSanpham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BienTheSanphamExists(bienTheSanpham.Bientheid))
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
            ViewData["Sanphamid"] = new SelectList(_context.SanPhams, "Sanphamid", "Sanphamid", bienTheSanpham.Sanphamid);
            return View(bienTheSanpham);
        }

        // GET: BienTheSanphams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienTheSanpham = await _context.BienTheSanphams
                .Include(b => b.Sanpham)
                .FirstOrDefaultAsync(m => m.Bientheid == id);
            if (bienTheSanpham == null)
            {
                return NotFound();
            }

            return View(bienTheSanpham);
        }

        // POST: BienTheSanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bienTheSanpham = await _context.BienTheSanphams.FindAsync(id);
            if (bienTheSanpham != null)
            {
                _context.BienTheSanphams.Remove(bienTheSanpham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BienTheSanphamExists(int id)
        {
            return _context.BienTheSanphams.Any(e => e.Bientheid == id);
        }
    }
}
