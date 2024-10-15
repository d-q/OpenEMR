using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenEMR.Data;
using OpenEMR.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenEMR.Controllers
{
    public class KunjungansController : Controller
    {
        private readonly OpenEMRContext _context;

        public KunjungansController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: Kunjungans
        public async Task<IActionResult> Index()
        {
            var openEMRContext = _context.Kunjungan.Include(k => k.Dokter).Include(k => k.Pasien).Include(k => k.Penjamin);
            return View(await openEMRContext.ToListAsync());
        }

        // GET: Kunjungans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunjungan = await _context.Kunjungan
                .Include(k => k.Dokter)
                .Include(k => k.Pasien)
                .Include(k => k.Penjamin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kunjungan == null)
            {
                return NotFound();
            }

            return View(kunjungan);
        }

        // GET: Kunjungans/Create
        public IActionResult Create()
        {
            var today = DateTime.Now;
            var nomorUrut = (_context.Kunjungan.Count() + 1).ToString("D3"); // 3 digit angka urut yang bertambah setiap hari
            ViewBag.NomorRegis = $"{today:ddMMyy}{nomorUrut}";

            ViewData["DokterId"] = new SelectList(_context.Dokter, "Id", "FirstName");
            ViewData["PasienId"] = new SelectList(_context.Pasien, "NomorRekamMedis", "NomorRekamMedis");
            ViewData["PenjaminId"] = new SelectList(_context.Penjamin, "Id", "NamaPenjamin");
            PopulateKunjungansDropDownList();
            return View();
        }

        // POST: Kunjungans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PasienId,DokterId,StatusPasien,WaktuMendaftar,PenjaminId,NomorRegis,Tindakans")] Kunjungan kunjungan)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(kunjungan.NomorRegis))
                {
                    var today = DateTime.Now;
                    var nomorUrut = (_context.Kunjungan.Count() + 1).ToString("D3"); // 3 digit angka urut yang bertambah setiap hari
                    kunjungan.NomorRegis = $"{today:ddMMyy}{nomorUrut}";
                }

                _context.Add(kunjungan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DokterId"] = new SelectList(_context.Dokter, "Id", "FirstName", kunjungan.DokterId);
            ViewData["PasienId"] = new SelectList(_context.Pasien, "NomorRekamMedis", "NomorRekamMedis", kunjungan.PasienId);
            ViewData["PenjaminId"] = new SelectList(_context.Penjamin, "Id", "NamaPenjamin", kunjungan.PenjaminId);
            PopulateKunjungansDropDownList();
            return View(kunjungan);
        }

        // GET: Kunjungans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunjungan = await _context.Kunjungan.FindAsync(id);
            if (kunjungan == null)
            {
                return NotFound();
            }
            ViewData["DokterId"] = new SelectList(_context.Dokter, "Id", "FirstName", kunjungan.DokterId);
            ViewData["PasienId"] = new SelectList(_context.Pasien, "NomorRekamMedis", "NomorRekamMedis", kunjungan.PasienId);
            ViewData["PenjaminId"] = new SelectList(_context.Penjamin, "Id", "NamaPenjamin", kunjungan.PenjaminId);
            PopulateKunjungansDropDownList();

            // Menyediakan daftar tindakan dan pegawai untuk dropdown
            ViewBag.TindakanList = _context.Pemeriksaan.ToList();
            ViewBag.PegawaiList = _context.Pegawai.ToList();
            ViewBag.Tindakans = await _context.Kunjungan
                .Include(k => k.Tindakans) // Menyertakan Tindakans
                .FirstOrDefaultAsync(k => k.Id == id);
            ViewBag.SkalaNyeriEnum = new SelectList(Enum.GetValues(typeof(SkalaNyeriEnum)));
            ViewBag.AdaNyeriOptions = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Text = "Ada", Value = "true" },
                new SelectListItem { Text = "Tidak Ada", Value = "false" }
            }, "Value", "Text", kunjungan.AdaNyeri);


            return View(kunjungan);
        }

        // POST: Kunjungans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,PasienId,DokterId,StatusPasien,WaktuMendaftar,PenjaminId,NomorRegis,Tindakans,AdaNyeri,SkalaNyeri,LokasiNyeri,PenyebabNyeri,DurasiNyeri,FrekuensiNyeri")] Kunjungan kunjungan)
        public async Task<IActionResult> Edit(int id, Kunjungan kunjungan)
        {
            if (id != kunjungan.Id)
            {
                return NotFound();
            }

            // Setelah Kunjungan tersimpan, simpan Tindakan terkait dengan Kunjungan
            if (kunjungan.Tindakans != null && kunjungan.Tindakans.Count > 0)
            {
                foreach (var tindakan in kunjungan.Tindakans)
                {
                    if (tindakan.Id == 0)  // Cek jika Id tindakan adalah 0 (belum ada di database)
                    {
                        tindakan.KunjunganId = id;  // Gunakan Id Kunjungan yang baru saja disimpan
                        _context.Tindakan.Add(tindakan);  // Tambahkan setiap tindakan ke dalam context
                    }
                }
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kunjungan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KunjunganExists(kunjungan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                PopulateKunjungansDropDownList();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DokterId"] = new SelectList(_context.Dokter, "Id", "FirstName", kunjungan.DokterId);
            ViewData["PasienId"] = new SelectList(_context.Pasien, "NomorRekamMedis", "NomorRekamMedis", kunjungan.PasienId);
            ViewData["PenjaminId"] = new SelectList(_context.Penjamin, "Id", "NamaPenjamin", kunjungan.PenjaminId);

            // Menyediakan daftar tindakan dan pegawai untuk dropdown
            ViewBag.TindakanList = _context.Pemeriksaan.ToList();
            ViewBag.PegawaiList = _context.Pegawai.ToList();
            ViewBag.Tindakans = await _context.Kunjungan
                .Include(k => k.Tindakans) // Menyertakan Tindakans
                .FirstOrDefaultAsync(k => k.Id == id);
            ViewBag.SkalaNyeriEnum = new SelectList(Enum.GetValues(typeof(SkalaNyeriEnum)));
            ViewBag.AdaNyeriOptions = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Text = "Ada", Value = "true" },
                new SelectListItem { Text = "Tidak Ada", Value = "false" }
            }, "Value", "Text", kunjungan.AdaNyeri);

            return View(kunjungan);
        }

        // GET: Kunjungans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kunjungan = await _context.Kunjungan
                .Include(k => k.Dokter)
                .Include(k => k.Pasien)
                .Include(k => k.Penjamin)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kunjungan == null)
            {
                return NotFound();
            }

            return View(kunjungan);
        }

        // POST: Kunjungans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kunjungan = await _context.Kunjungan.FindAsync(id);
            _context.Kunjungan.Remove(kunjungan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KunjunganExists(int id)
        {
            return _context.Kunjungan.Any(e => e.Id == id);
        }

        private void PopulateKunjungansDropDownList(object selectedDepartment = null)
        {
            ViewBag.StatusPasien = Enum.GetValues(typeof(StatusPasien))
                       .Cast<StatusPasien>()
                       .Select(e => new
                       {
                           ID = (int)e,
                           Name = e.GetType()
                                   .GetField(e.ToString())
                                   .GetCustomAttributes(typeof(DisplayAttribute), false)
                                   .Cast<DisplayAttribute>()
                                   .FirstOrDefault()?.Name ?? e.ToString()
                       }).ToList();
        }
    }
}
