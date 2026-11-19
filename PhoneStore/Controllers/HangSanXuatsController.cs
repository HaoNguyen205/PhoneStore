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
    public class HangSanXuatsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HangSanXuatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HangSanXuats
        public async Task<IActionResult> Index()
        {
            return View(await _context.HangSanXuats.ToListAsync());
        }

        // GET: HangSanXuats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangSanXuat = await _context.HangSanXuats
                .FirstOrDefaultAsync(m => m.Hangid == id);
            if (hangSanXuat == null)
            {
                return NotFound();
            }

            return View(hangSanXuat);
        }

        // GET: HangSanXuats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HangSanXuats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Hangid,Tenhang,Logo,Thutu,Kichhoat")] HangSanXuat hangSanXuat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hangSanXuat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hangSanXuat);
        }

        // GET: HangSanXuats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangSanXuat = await _context.HangSanXuats.FindAsync(id);
            if (hangSanXuat == null)
            {
                return NotFound();
            }
            return View(hangSanXuat);
        }

        // POST: HangSanXuats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Hangid,Tenhang,Logo,Thutu,Kichhoat")] HangSanXuat hangSanXuat)
        {
            if (id != hangSanXuat.Hangid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hangSanXuat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangSanXuatExists(hangSanXuat.Hangid))
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
            return View(hangSanXuat);
        }

        // GET: HangSanXuats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangSanXuat = await _context.HangSanXuats
                .FirstOrDefaultAsync(m => m.Hangid == id);
            if (hangSanXuat == null)
            {
                return NotFound();
            }

            return View(hangSanXuat);
        }

        // POST: HangSanXuats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hangSanXuat = await _context.HangSanXuats.FindAsync(id);
            if (hangSanXuat != null)
            {
                _context.HangSanXuats.Remove(hangSanXuat);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangSanXuatExists(int id)
        {
            return _context.HangSanXuats.Any(e => e.Hangid == id);
        }
    }
}
