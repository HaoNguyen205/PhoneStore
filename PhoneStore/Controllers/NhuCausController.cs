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
    public class NhuCausController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NhuCausController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NhuCaus
        public async Task<IActionResult> Index()
        {
            return View(await _context.NhuCaus.ToListAsync());
        }

        // GET: NhuCaus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhuCau = await _context.NhuCaus
                .FirstOrDefaultAsync(m => m.Nhucauid == id);
            if (nhuCau == null)
            {
                return NotFound();
            }

            return View(nhuCau);
        }

        // GET: NhuCaus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NhuCaus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nhucauid,Tennhucau,Thutu,Kichhoat")] NhuCau nhuCau)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nhuCau);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nhuCau);
        }

        // GET: NhuCaus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhuCau = await _context.NhuCaus.FindAsync(id);
            if (nhuCau == null)
            {
                return NotFound();
            }
            return View(nhuCau);
        }

        // POST: NhuCaus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nhucauid,Tennhucau,Thutu,Kichhoat")] NhuCau nhuCau)
        {
            if (id != nhuCau.Nhucauid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nhuCau);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NhuCauExists(nhuCau.Nhucauid))
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
            return View(nhuCau);
        }

        // GET: NhuCaus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nhuCau = await _context.NhuCaus
                .FirstOrDefaultAsync(m => m.Nhucauid == id);
            if (nhuCau == null)
            {
                return NotFound();
            }

            return View(nhuCau);
        }

        // POST: NhuCaus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nhuCau = await _context.NhuCaus.FindAsync(id);
            if (nhuCau != null)
            {
                _context.NhuCaus.Remove(nhuCau);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NhuCauExists(int id)
        {
            return _context.NhuCaus.Any(e => e.Nhucauid == id);
        }
    }
}
