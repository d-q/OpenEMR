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
    public class OrderFarmasisController : Controller
    {
        private readonly OpenEMRContext _context;

        public OrderFarmasisController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: OrderFarmasis
        public async Task<IActionResult> Index()
        {
            var openEMRContext = _context.OrderFarmasi.Include(o => o.Kunjungan).Include(o => o.Pasien).Include(o => o.Pegawai);
            return View(await openEMRContext.ToListAsync());
        }

        // GET: OrderFarmasis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderFarmasi = await _context.OrderFarmasi
                .Include(o => o.Kunjungan)
                .Include(o => o.Pasien)
                .Include(o => o.Pegawai)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderFarmasi == null)
            {
                return NotFound();
            }

            return View(orderFarmasi);
        }

        // GET: OrderFarmasis/Create
        public IActionResult Create()
        {
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "NomorRegis");
            ViewData["PasienId"] = new SelectList(_context.Pasien, "NomorRekamMedis", "NomorRekamMedis");
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi");
            return View();
        }

        // POST: OrderFarmasis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PegawaiId,KunjunganId,PasienId,WaktuPermintaanOrder,NomorPemeriksaan")] OrderFarmasi orderFarmasi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderFarmasi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "NomorRegis", orderFarmasi.KunjunganId);
            ViewData["PasienId"] = new SelectList(_context.Pasien, "NomorRekamMedis", "NomorRekamMedis", orderFarmasi.PasienId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi", orderFarmasi.PegawaiId);
            return View(orderFarmasi);
        }

        // GET: OrderFarmasis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderFarmasi = await _context.OrderFarmasi.FindAsync(id);
            if (orderFarmasi == null)
            {
                return NotFound();
            }
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "NomorRegis", orderFarmasi.KunjunganId);
            ViewData["PasienId"] = new SelectList(_context.Pasien, "NomorRekamMedis", "NomorRekamMedis", orderFarmasi.PasienId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi", orderFarmasi.PegawaiId);
            return View(orderFarmasi);
        }

        // POST: OrderFarmasis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PegawaiId,KunjunganId,PasienId,WaktuPermintaanOrder,NomorPemeriksaan")] OrderFarmasi orderFarmasi)
        {
            if (id != orderFarmasi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderFarmasi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderFarmasiExists(orderFarmasi.Id))
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
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "NomorRegis", orderFarmasi.KunjunganId);
            ViewData["PasienId"] = new SelectList(_context.Pasien, "NomorRekamMedis", "NomorRekamMedis", orderFarmasi.PasienId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "AlamatEmailPribadi", orderFarmasi.PegawaiId);
            return View(orderFarmasi);
        }

        // GET: OrderFarmasis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderFarmasi = await _context.OrderFarmasi
                .Include(o => o.Kunjungan)
                .Include(o => o.Pasien)
                .Include(o => o.Pegawai)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (orderFarmasi == null)
            {
                return NotFound();
            }

            return View(orderFarmasi);
        }

        // POST: OrderFarmasis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderFarmasi = await _context.OrderFarmasi.FindAsync(id);
            _context.OrderFarmasi.Remove(orderFarmasi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderFarmasiExists(int id)
        {
            return _context.OrderFarmasi.Any(e => e.Id == id);
        }
    }
}
