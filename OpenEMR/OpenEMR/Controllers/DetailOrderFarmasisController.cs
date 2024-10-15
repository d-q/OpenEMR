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
    public class DetailOrderFarmasisController : Controller
    {
        private readonly OpenEMRContext _context;

        public DetailOrderFarmasisController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: DetailOrderFarmasis
        public async Task<IActionResult> Index()
        {
            var openEMRContext = _context.DetailOrderFarmasi.Include(d => d.Barang).Include(d => d.OrderFarmasi);
            return View(await openEMRContext.ToListAsync());
        }

        // GET: DetailOrderFarmasis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailOrderFarmasi = await _context.DetailOrderFarmasi
                .Include(d => d.Barang)
                .Include(d => d.OrderFarmasi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detailOrderFarmasi == null)
            {
                return NotFound();
            }

            return View(detailOrderFarmasi);
        }

        // GET: DetailOrderFarmasis/Create
        public IActionResult Create()
        {
            ViewData["BarangId"] = new SelectList(_context.Barang, "KodeBarang", "KodeBarang");
            ViewData["OrderFarmasiId"] = new SelectList(_context.OrderFarmasi, "Id", "NomorPemeriksaan");
            return View();
        }

        // POST: DetailOrderFarmasis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderFarmasiId,BarangId,Jumlah,AturanPakai,Keterangan")] DetailOrderFarmasi detailOrderFarmasi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detailOrderFarmasi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BarangId"] = new SelectList(_context.Barang, "KodeBarang", "KodeBarang", detailOrderFarmasi.BarangId);
            ViewData["OrderFarmasiId"] = new SelectList(_context.OrderFarmasi, "Id", "NomorPemeriksaan", detailOrderFarmasi.OrderFarmasiId);
            return View(detailOrderFarmasi);
        }

        // GET: DetailOrderFarmasis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailOrderFarmasi = await _context.DetailOrderFarmasi.FindAsync(id);
            if (detailOrderFarmasi == null)
            {
                return NotFound();
            }
            ViewData["BarangId"] = new SelectList(_context.Barang, "KodeBarang", "KodeBarang", detailOrderFarmasi.BarangId);
            ViewData["OrderFarmasiId"] = new SelectList(_context.OrderFarmasi, "Id", "NomorPemeriksaan", detailOrderFarmasi.OrderFarmasiId);
            return View(detailOrderFarmasi);
        }

        // POST: DetailOrderFarmasis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderFarmasiId,BarangId,Jumlah,AturanPakai,Keterangan")] DetailOrderFarmasi detailOrderFarmasi)
        {
            if (id != detailOrderFarmasi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detailOrderFarmasi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetailOrderFarmasiExists(detailOrderFarmasi.Id))
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
            ViewData["BarangId"] = new SelectList(_context.Barang, "KodeBarang", "KodeBarang", detailOrderFarmasi.BarangId);
            ViewData["OrderFarmasiId"] = new SelectList(_context.OrderFarmasi, "Id", "NomorPemeriksaan", detailOrderFarmasi.OrderFarmasiId);
            return View(detailOrderFarmasi);
        }

        // GET: DetailOrderFarmasis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detailOrderFarmasi = await _context.DetailOrderFarmasi
                .Include(d => d.Barang)
                .Include(d => d.OrderFarmasi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detailOrderFarmasi == null)
            {
                return NotFound();
            }

            return View(detailOrderFarmasi);
        }

        // POST: DetailOrderFarmasis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detailOrderFarmasi = await _context.DetailOrderFarmasi.FindAsync(id);
            _context.DetailOrderFarmasi.Remove(detailOrderFarmasi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetailOrderFarmasiExists(int id)
        {
            return _context.DetailOrderFarmasi.Any(e => e.Id == id);
        }
    }
}
