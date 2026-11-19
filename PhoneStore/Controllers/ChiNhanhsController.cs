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
    public class ChiNhanhsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChiNhanhsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ChiNhanhs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ChiNhanhs.ToListAsync());
        }

        // GET: ChiNhanhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiNhanh = await _context.ChiNhanhs
                .FirstOrDefaultAsync(m => m.Chinhanhid == id);
            if (chiNhanh == null)
            {
                return NotFound();
            }

            return View(chiNhanh);
        }

        // GET: ChiNhanhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ChiNhanhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Chinhanhid,Khuvuc,Tenchinhanh,Diachi,Sodienthoai")] ChiNhanh chiNhanh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chiNhanh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chiNhanh);
        }

        // GET: ChiNhanhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiNhanh = await _context.ChiNhanhs.FindAsync(id);
            if (chiNhanh == null)
            {
                return NotFound();
            }
            return View(chiNhanh);
        }

        // POST: ChiNhanhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Chinhanhid,Khuvuc,Tenchinhanh,Diachi,Sodienthoai")] ChiNhanh chiNhanh)
        {
            if (id != chiNhanh.Chinhanhid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiNhanh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiNhanhExists(chiNhanh.Chinhanhid))
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
            return View(chiNhanh);
        }

        // GET: ChiNhanhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chiNhanh = await _context.ChiNhanhs
                .FirstOrDefaultAsync(m => m.Chinhanhid == id);
            if (chiNhanh == null)
            {
                return NotFound();
            }

            return View(chiNhanh);
        }

        // POST: ChiNhanhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chiNhanh = await _context.ChiNhanhs.FindAsync(id);
            if (chiNhanh != null)
            {
                _context.ChiNhanhs.Remove(chiNhanh);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiNhanhExists(int id)
        {
            return _context.ChiNhanhs.Any(e => e.Chinhanhid == id);
        }
    }
}
