using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenEMR.Data;
using OpenEMR.Models;

namespace OpenEMR.Controllers
{
    public class DetailOrderLabsController : Controller
    {
        private readonly OpenEMRContext _context;

        public DetailOrderLabsController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: DetailOrderLabs
        public async Task<IActionResult> Index()
        {
            var openEMRContext = _context.DetailOrderLab.Include(d => d.OrderLab).Include(d => d.Pemeriksa).Include(d => d.Pemeriksaan);
            return View(await openEMRContext.ToListAsync());
        }

        // GET: DetailOrderLabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailOrderLab = await _context.DetailOrderLab
                .Include(d => d.OrderLab)
                .Include(d => d.Pemeriksa)
                .Include(d => d.Pemeriksaan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detailOrderLab == null)
            {
                return NotFound();
            }

            return View(detailOrderLab);
        }

        // GET: DetailOrderLabs/Create
        public IActionResult Create()
        {
            ViewData["OrderLabId"] = new SelectList(_context.OrderLab, "Id", "NomorOrderLab");
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi");
            ViewData["PemeriksaanId"] = new SelectList(_context.Pemeriksaan, "Id", "KategoriPemeriksaan");
            return View();
        }

        // POST: DetailOrderLabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PegawaiId,PemeriksaanId,WaktuDilakukanPemeriksaan,NilaiMinimal,NilaiMaksimal,HasilPemeriksaan,OrderLabId")] DetailOrderLab detailOrderLab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detailOrderLab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderLabId"] = new SelectList(_context.OrderLab, "Id", "NomorOrderLab", detailOrderLab.OrderLabId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi", detailOrderLab.PegawaiId);
            ViewData["PemeriksaanId"] = new SelectList(_context.Pemeriksaan, "Id", "KategoriPemeriksaan", detailOrderLab.PemeriksaanId);
            return View(detailOrderLab);
        }

        // GET: DetailOrderLabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailOrderLab = await _context.DetailOrderLab.FindAsync(id);
            if (detailOrderLab == null)
            {
                return NotFound();
            }
            ViewData["OrderLabId"] = new SelectList(_context.OrderLab, "Id", "NomorOrderLab", detailOrderLab.OrderLabId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi", detailOrderLab.PegawaiId);
            ViewData["PemeriksaanId"] = new SelectList(_context.Pemeriksaan, "Id", "KategoriPemeriksaan", detailOrderLab.PemeriksaanId);
            return View(detailOrderLab);
        }

        // POST: DetailOrderLabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PegawaiId,PemeriksaanId,WaktuDilakukanPemeriksaan,NilaiMinimal,NilaiMaksimal,HasilPemeriksaan,OrderLabId")] DetailOrderLab detailOrderLab)
        {
            if (id != detailOrderLab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detailOrderLab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailOrderLabExists(detailOrderLab.Id))
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
            ViewData["OrderLabId"] = new SelectList(_context.OrderLab, "Id", "NomorOrderLab", detailOrderLab.OrderLabId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi", detailOrderLab.PegawaiId);
            ViewData["PemeriksaanId"] = new SelectList(_context.Pemeriksaan, "Id", "KategoriPemeriksaan", detailOrderLab.PemeriksaanId);
            return View(detailOrderLab);
        }

        // GET: DetailOrderLabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailOrderLab = await _context.DetailOrderLab
                .Include(d => d.OrderLab)
                .Include(d => d.Pemeriksa)
                .Include(d => d.Pemeriksaan)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detailOrderLab == null)
            {
                return NotFound();
            }

            return View(detailOrderLab);
        }

        // POST: DetailOrderLabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detailOrderLab = await _context.DetailOrderLab.FindAsync(id);
            _context.DetailOrderLab.Remove(detailOrderLab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailOrderLabExists(int id)
        {
            return _context.DetailOrderLab.Any(e => e.Id == id);
        }
    }
}
