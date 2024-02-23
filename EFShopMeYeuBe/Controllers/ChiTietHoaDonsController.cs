using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFShopMeYeuBe.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Query;

namespace EFShopMeYeuBe.Controllers
{
    public class ChiTietHoaDonsController : Controller
    {
        private readonly CdnShopMeYeuBeContext _context;

        public ChiTietHoaDonsController(CdnShopMeYeuBeContext context)
        {
            _context = context;
        }

        // GET: ChiTietHoaDons
        public async Task<IActionResult> Index(int? id)
        {
            IQueryable<ChiTietHoaDon> cdnShopMeYeuBeContext;
            if (id != null)
            {
                ViewBag.hdid = id;
                cdnShopMeYeuBeContext = _context.ChiTietHoaDons.Include(c => c.ChiTietSanPham).Include(c => c.MaHdNavigation).Include(c => c.ChiTietSanPham.MaSpNavigation).Where(x => x.MaHd == id);
            }
            else
                 cdnShopMeYeuBeContext = _context.ChiTietHoaDons.Include(c => c.ChiTietSanPham).Include(c => c.MaHdNavigation).Include(c => c.ChiTietSanPham.MaSpNavigation);
            return View(await cdnShopMeYeuBeContext.ToListAsync());
        }

        // GET: ChiTietHoaDons/Details/5
        public async Task<IActionResult> Details(int? hd_id,int? sp_id,string? size)
        {
            if (hd_id == null || sp_id == null || size == null || _context.ChiTietHoaDons == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDons
                .Include(c => c.ChiTietSanPham)
                .Include(c => c.MaHdNavigation)
                .Include(c => c.ChiTietSanPham.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaHd == hd_id && m.MaSp == sp_id && m.Size == size);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Create
        public IActionResult Create(int? id)
        {
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "TenSp");
            if(id!= null)
            {
                ViewBag.id = id;
                ViewData["MaHd"] = new SelectList(_context.HoaDons.Where(x=>x.MaHd==id), "MaHd", "MaHd");
            }
            else
            {
                ViewData["MaHd"] = new SelectList(_context.HoaDons, "MaHd", "MaHd");
            }
            return View();
        }
        [HttpPost]
        public JsonResult ChangeSP(int id_sp)
        {
            var sanpham = _context.ChiTietSanPhams.Where(x=>x.MaSp == id_sp).ToList();
            return Json(sanpham);
        }

            // POST: ChiTietHoaDons/Create
            // To protect from overposting attacks, enable the specific properties you want to bind to.
            // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id,[Bind("MaHd,MaSp,SoLban,Size")] ChiTietHoaDon chiTietHoaDon)
        {
            if (ModelState.IsValid)
            {
                if (ChiTietHoaDonExists(chiTietHoaDon.MaHd, chiTietHoaDon.MaSp, chiTietHoaDon.Size))
                {
                    ViewBag.Err = "Hóa đơn này đã tồn tại sản phẩm với size này";
                }
                else
                {
                    _context.Add(chiTietHoaDon);
                    await _context.SaveChangesAsync();
                    if (id != null)
                        return RedirectToAction(nameof(Index), new { id = id });
                    else
                        return RedirectToAction(nameof(Index));
                }
            }
            ViewData["MaSp"] = new SelectList(_context.SanPhams, "MaSp", "TenSp", chiTietHoaDon.MaSp);
            ViewData["MaHd"] = new SelectList(_context.HoaDons, "MaHd", "MaHd", chiTietHoaDon.MaHd);
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Edit/5
        public async Task<IActionResult> Edit(int? hd_id, int? sp_id, string? size)
        {
            if (hd_id == null || sp_id == null || size == null || _context.ChiTietHoaDons == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDons.FindAsync(hd_id,sp_id,size);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }
            ViewData["MaSp"] = new SelectList(_context.ChiTietSanPhams, "MaSp", "Size", chiTietHoaDon.MaSp);
            ViewData["MaHd"] = new SelectList(_context.HoaDons, "MaHd", "MaHd", chiTietHoaDon.MaHd);
            var sanpham = _context.SanPhams.Find(sp_id);
            if (sanpham != null)
            {
                ViewBag.TenSP = sanpham.TenSp;
            }
            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDons/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id_mahd, int id_masp, string id_size, [Bind("MaHd,MaSp,SoLban,Size")] ChiTietHoaDon chiTietHoaDon)
        {
            if (id_mahd != chiTietHoaDon.MaHd || id_size != chiTietHoaDon.Size || id_masp != chiTietHoaDon.MaSp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chiTietHoaDon);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChiTietHoaDonExists(chiTietHoaDon.MaHd,chiTietHoaDon.MaSp,chiTietHoaDon.Size))
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
            ViewData["MaSp"] = new SelectList(_context.ChiTietSanPhams, "MaSp", "Size", chiTietHoaDon.MaSp);
            ViewData["MaHd"] = new SelectList(_context.HoaDons, "MaHd", "MaHd", chiTietHoaDon.MaHd);
            return View(chiTietHoaDon);
        }

        // GET: ChiTietHoaDons/Delete/5
        public async Task<IActionResult> Delete(int? hd_id, int? sp_id, string? size)
        {
            if (hd_id == null || sp_id == null || size == null || _context.ChiTietHoaDons == null)
            {
                return NotFound();
            }

            var chiTietHoaDon = await _context.ChiTietHoaDons
                .Include(c => c.ChiTietSanPham)
                .Include(c => c.MaHdNavigation)
                .Include(c => c.ChiTietSanPham.MaSpNavigation)
                .FirstOrDefaultAsync(m => m.MaHd == hd_id && m.Size == size && m.MaSp == sp_id);
            if (chiTietHoaDon == null)
            {
                return NotFound();
            }

            return View(chiTietHoaDon);
        }

        // POST: ChiTietHoaDons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int mahd,int masp, string size)
        {
            if (_context.ChiTietHoaDons == null)
            {
                return Problem("Entity set 'CdnShopMeYeuBeContext.ChiTietHoaDons'  is null.");
            }
            var chiTietHoaDon = await _context.ChiTietHoaDons.FindAsync(mahd,masp,size);
            if (chiTietHoaDon != null)
            {
                _context.ChiTietHoaDons.Remove(chiTietHoaDon);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChiTietHoaDonExists(int id,int sp_id,string size)
        {
          return (_context.ChiTietHoaDons?.Any(e => e.MaHd == id && e.MaSp == sp_id && e.Size == size)).GetValueOrDefault();
        }
    }
}
