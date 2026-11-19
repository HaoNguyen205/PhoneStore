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
    public class TinCongNghesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TinCongNghesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TinCongNghes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TinCongNghes.ToListAsync());
        }

        // GET: TinCongNghes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinCongNghe = await _context.TinCongNghes
                .FirstOrDefaultAsync(m => m.Tinid == id);
            if (tinCongNghe == null)
            {
                return NotFound();
            }

            return View(tinCongNghe);
        }

        // GET: TinCongNghes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TinCongNghes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tinid,Tieude,Tomtat,Noidung,Hinhanh,Nguoidang,Ngaydang,Luotxem,Kichhoat")] TinCongNghe tinCongNghe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tinCongNghe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tinCongNghe);
        }

        // GET: TinCongNghes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinCongNghe = await _context.TinCongNghes.FindAsync(id);
            if (tinCongNghe == null)
            {
                return NotFound();
            }
            return View(tinCongNghe);
        }

        // POST: TinCongNghes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Tinid,Tieude,Tomtat,Noidung,Hinhanh,Nguoidang,Ngaydang,Luotxem,Kichhoat")] TinCongNghe tinCongNghe)
        {
            if (id != tinCongNghe.Tinid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tinCongNghe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TinCongNgheExists(tinCongNghe.Tinid))
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
            return View(tinCongNghe);
        }

        // GET: TinCongNghes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tinCongNghe = await _context.TinCongNghes
                .FirstOrDefaultAsync(m => m.Tinid == id);
            if (tinCongNghe == null)
            {
                return NotFound();
            }

            return View(tinCongNghe);
        }

        // POST: TinCongNghes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tinCongNghe = await _context.TinCongNghes.FindAsync(id);
            if (tinCongNghe != null)
            {
                _context.TinCongNghes.Remove(tinCongNghe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TinCongNgheExists(int id)
        {
            return _context.TinCongNghes.Any(e => e.Tinid == id);
        }
    }
}
