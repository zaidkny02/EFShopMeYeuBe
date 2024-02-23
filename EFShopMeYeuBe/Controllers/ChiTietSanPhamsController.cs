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
    public class ChiTietSanPhamsController : Controller
    {
        private readonly CdnShopMeYeuBeContext _context;

        public ChiTietSanPhamsController(CdnShopMeYeuBeContext context)
        {
            _context = context;
        }

        // GET: ChiTietSanPhams
        public async Task<IActionResult> Index()
        {
            var cdnShopMeYeuBeContext = _context.ChiTietSanPhams.Include(c => c.MaSpNavigation);
            return View(await cdnShopMeYeuBeContext.ToListAsync());
        }

        // GET: ChiTietSanPhams/Details/5
        public async Task<IActionResult> Details(int? masp , string? size)
        {
            if (masp == null || size == null || _context.ChiTietSanPhams == null)
            {
                return NotFound();
            }

            var chiTietSanPham = await _context.ChiTietSanPhams
                .Include(c => c.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == masp && m.Size == size);
            if (chiTietSanPham == null)
            {
                return NotFound();
            }

            return View(chiTietSanPham);
        }

        // GET: ChiTietSanPhams/Create
        public IActionResult Create()
        {
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "TenSp");
            return View();
        }

        // POST: ChiTietSanPhams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaSp,Size,SoLuongTheoSize")] ChiTietSanPham chiTietSanPham)
        {
            if (ModelState.IsValid)
            {
                if(ChiTietSanPhamExists(chiTietSanPham.MaSp,chiTietSanPham.Size))
                {
                    ViewBag.Err = "Đã tồn tại Size này";
                }
                else
                {
                    _context.Add(chiTietSanPham);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietSanPham.MaSp);
            return View(chiTietSanPham);
        }

        // GET: ChiTietSanPhams/Edit/5
        public async Task<IActionResult> Edit(int? masp, string? size)
        {
            if (masp == null || size == null|| _context.ChiTietSanPhams == null)
            {
                return NotFound();
            }

            var chiTietSanPham = await _context.ChiTietSanPhams.FindAsync(masp,size);
            if (chiTietSanPham == null)
            {
                return NotFound();
            }
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietSanPham.MaSp);
            var sanpham = _context.SanPhams.Find(masp);
            if(sanpham != null) {
                ViewBag.TenSP = sanpham.TenSp;
            }
            return View(chiTietSanPham);
        }

        // POST: ChiTietSanPhams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id_masp,string id_size, [Bind("MaSp,Size,SoLuongTheoSize")] ChiTietSanPham chiTietSanPham)
        {
            if (id_masp != chiTietSanPham.MaSp || id_size != chiTietSanPham.Size )
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                    try
                    {
                        _context.Update(chiTietSanPham);
                        await _context.SaveChangesAsync();

                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ChiTietSanPhamExists(chiTietSanPham.MaSp, chiTietSanPham.Size))
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
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "MaSp", chiTietSanPham.MaSp);
            return View(chiTietSanPham);
        }

        // GET: ChiTietSanPhams/Delete/5
        public async Task<IActionResult> Delete(int? masp, string? size)
        {
            if (masp == null || size ==null || _context.ChiTietSanPhams == null)
            {
                return NotFound();
            }

            var chiTietSanPham = await _context.ChiTietSanPhams
                .Include(c => c.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaSp == masp && m.Size == size);
            if (chiTietSanPham == null)
            {
                return NotFound();
            }

            return View(chiTietSanPham);
        }

        // POST: ChiTietSanPhams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int masp, string size)
        {
            if (_context.ChiTietSanPhams == null)
            {
                return Problem("Entity set 'CdnShopMeYeuBeContext.ChiTietSanPhams'  is null.");
            }
            var chiTietSanPham = await _context.ChiTietSanPhams.FindAsync(masp,size);
            if (chiTietSanPham != null)
            {
                _context.ChiTietSanPhams.Remove(chiTietSanPham);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietSanPhamExists(int id,string size)
        {
          return (_context.ChiTietSanPhams?.Any(e => e.MaSp == id && e.Size == size)).GetValueOrDefault();
        }
        
    }
}
