using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFShopMeYeuBe.Models;

namespace EFShopMeYeuBe.Controllers
{
    public class HangsController : Controller
    {
        private readonly CdnShopMeYeuBeContext _context;

        public HangsController(CdnShopMeYeuBeContext context)
        {
            _context = context;
        }

        // GET: Hangs
        public async Task<IActionResult> Index()
        {
              return _context.Hangs != null ? 
                          View(await _context.Hangs.ToListAsync()) :
                          Problem("Entity set 'CdnShopMeYeuBeContext.Hangs'  is null.");
        }

        // GET: Hangs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Hangs == null)
            {
                return NotFound();
            }

            var hang = await _context.Hangs
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (hang == null)
            {
                return NotFound();
            }

            return View(hang);
        }

        // GET: Hangs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHang,TenHang")] Hang hang)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hang);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hang);
        }

        // GET: Hangs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Hangs == null)
            {
                return NotFound();
            }

            var hang = await _context.Hangs.FindAsync(id);
            if (hang == null)
            {
                return NotFound();
            }
            return View(hang);
        }

        // POST: Hangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHang,TenHang")] Hang hang)
        {
            if (id != hang.MaHang)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hang);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangExists(hang.MaHang))
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
            return View(hang);
        }

        // GET: Hangs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Hangs == null)
            {
                return NotFound();
            }

            var hang = await _context.Hangs
                .FirstOrDefaultAsync(m => m.MaHang == id);
            if (hang == null)
            {
                return NotFound();
            }

            return View(hang);
        }

        // POST: Hangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Hangs == null)
            {
                return Problem("Entity set 'CdnShopMeYeuBeContext.Hangs'  is null.");
            }
            var hang = await _context.Hangs.FindAsync(id);
            if (hang != null)
            {
                _context.Hangs.Remove(hang);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangExists(int id)
        {
          return (_context.Hangs?.Any(e => e.MaHang == id)).GetValueOrDefault();
        }
    }
}
