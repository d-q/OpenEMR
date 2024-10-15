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
    public class OrderLabsController : Controller
    {
        private readonly OpenEMRContext _context;

        public OrderLabsController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: OrderLabs
        public async Task<IActionResult> Index()
        {
            var openEMRContext = _context.OrderLab.Include(o => o.Kunjungan).Include(o => o.Pemeriksa);
            return View(await openEMRContext.ToListAsync());
        }

        // GET: OrderLabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLab = await _context.OrderLab
                .Include(o => o.Kunjungan)
                .Include(o => o.Pemeriksa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderLab == null)
            {
                return NotFound();
            }

            return View(orderLab);
        }

        // GET: OrderLabs/Create
        public IActionResult Create()
        {
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "NomorRegis");
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi");
            return View();
        }

        // POST: OrderLabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PegawaiId,WaktuPermintaanOrder,NomorPemeriksaan,KunjunganId,NomorOrderLab")] OrderLab orderLab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderLab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "NomorRegis", orderLab.KunjunganId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi", orderLab.PegawaiId);
            return View(orderLab);
        }

        // GET: OrderLabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLab = await _context.OrderLab.FindAsync(id);
            if (orderLab == null)
            {
                return NotFound();
            }
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "NomorRegis", orderLab.KunjunganId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi", orderLab.PegawaiId);
            return View(orderLab);
        }

        // POST: OrderLabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PegawaiId,WaktuPermintaanOrder,NomorPemeriksaan,KunjunganId,NomorOrderLab")] OrderLab orderLab)
        {
            if (id != orderLab.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderLab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderLabExists(orderLab.Id))
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
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "NomorRegis", orderLab.KunjunganId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi", orderLab.PegawaiId);
            return View(orderLab);
        }

        // GET: OrderLabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderLab = await _context.OrderLab
                .Include(o => o.Kunjungan)
                .Include(o => o.Pemeriksa)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderLab == null)
            {
                return NotFound();
            }

            return View(orderLab);
        }

        // POST: OrderLabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderLab = await _context.OrderLab.FindAsync(id);
            _context.OrderLab.Remove(orderLab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderLabExists(int id)
        {
            return _context.OrderLab.Any(e => e.Id == id);
        }
    }
}
