using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenEMR.Data;
using OpenEMR.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenEMR.Controllers
{
    public class PasiensController : Controller
    {
        private readonly OpenEMRContext _context;

        public PasiensController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: Pasiens
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pasien.ToListAsync());
        }

        // GET: Pasiens/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasien = await _context.Pasien
                .FirstOrDefaultAsync(m => m.NomorRekamMedis == id);
            if (pasien == null)
            {
                return NotFound();
            }

            return View(pasien);
        }

        // GET: Pasiens/Create
        public IActionResult Create()
        {
            // Mendapatkan jumlah pasien yang ada
            int currentCount = _context.Pasien.Count();

            // Membuat format nomor rekam medis otomatis dengan format "000001", "000002", dll.
            string nomorRekamMedis = (currentCount + 1).ToString("D6"); // D6 format untuk padding angka dengan 6 digit

            // Menyimpan nomor rekam medis di ViewModel atau ViewBag
            ViewBag.NomorRekamMedis = nomorRekamMedis;

            PopulatePasiensDropDownList();
            var model = new Pasien();
            return View(model);
        }

        // POST: Pasiens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,NomorRekamMedis,NamaLengkap,NIK,NomorIdentitasLain,NamaIbuKandung,TempatLahir,TanggalLahir,JenisKelamin,Agama,Suku,BahasaYangDikuasai,AlamatLengkap,RT,RW,KelurahanDesa,Kecamatan,KotaKabupaten,KodePos,Provinsi,Negara,AlamatDomisili,RTDomisili,RWDomisili,KelurahanDesaDomisili,KecamatanDomisili,KotaKabupatenDomisili,KodePosDomisili,ProvinsiDomisili,NegaraDomisili,NomorTeleponRumah,NomorTeleponSelular,Pendidikan,Pekerjaan,StatusPernikahan")] Pasien pasien)
        {
            if (ModelState.IsValid)
            {

                // NomorRekamMedis diset readonly, sehingga perlu diisi ulang di server-side jika perlu
                if (string.IsNullOrEmpty(pasien.NomorRekamMedis))
                {
                    int currentCount = _context.Pasien.Count();
                    pasien.NomorRekamMedis = (currentCount + 1).ToString("D6"); // Mengisi jika kosong
                }

                _context.Add(pasien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pasien);
        }

        // GET: Pasiens/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var pasien = await _context.Pasien.FindAsync(id);
            var pasien = await _context.Pasien
                .FirstOrDefaultAsync(m => m.NomorRekamMedis == id);
            if (pasien == null)
            {
                return NotFound();
            }

            PopulatePasiensDropDownList();
            return View(pasien);
        }

        // POST: Pasiens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("NomorRekamMedis,NamaLengkap,NIK,NomorIdentitasLain,NamaIbuKandung,TempatLahir,TanggalLahir,JenisKelamin,Agama,Suku,BahasaYangDikuasai,AlamatLengkap,RT,RW,KelurahanDesa,Kecamatan,KotaKabupaten,KodePos,Provinsi,Negara,AlamatDomisili,RTDomisili,RWDomisili,KelurahanDesaDomisili,KecamatanDomisili,KotaKabupatenDomisili,KodePosDomisili,ProvinsiDomisili,NegaraDomisili,NomorTeleponRumah,NomorTeleponSelular,Pendidikan,Pekerjaan,StatusPernikahan")] Pasien pasien)
        {
            if (id != pasien.NomorRekamMedis)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasienExists(pasien.NomorRekamMedis))
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
            return View(pasien);
        }

        // GET: Pasiens/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasien = await _context.Pasien
                .FirstOrDefaultAsync(m => m.NomorRekamMedis == id);
            if (pasien == null)
            {
                return NotFound();
            }

            return View(pasien);
        }

        // POST: Pasiens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var pasien = await _context.Pasien
                .FirstOrDefaultAsync(m => m.NomorRekamMedis == id);
            _context.Pasien.Remove(pasien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasienExists(string id)
        {
            return _context.Pasien.Any(e => e.NomorRekamMedis == id);
        }

        private void PopulatePasiensDropDownList(object selectedDepartment = null)
        {
            // Status Pernikahan
            ViewBag.StatusPernikahan = Enum.GetValues(typeof(StatusPernikahan))
                                           .Cast<StatusPernikahan>()
                                           .Select(e => new
                                           {
                                               ID = (int)e,
                                               Name = e.GetType()
                                                       .GetField(e.ToString())
                                                       .GetCustomAttributes(typeof(DisplayAttribute), false)
                                                       .Cast<DisplayAttribute>()
                                                       .FirstOrDefault()?.Name ?? e.ToString()
                                           }).ToList();

            // Jenis Kelamin
            ViewBag.JenisKelamin = Enum.GetValues(typeof(JenisKelamin))
                                       .Cast<JenisKelamin>()
                                       .Select(e => new
                                       {
                                           ID = (int)e,
                                           Name = e.GetType()
                                                   .GetField(e.ToString())
                                                   .GetCustomAttributes(typeof(DisplayAttribute), false)
                                                   .Cast<DisplayAttribute>()
                                                   .FirstOrDefault()?.Name ?? e.ToString()
                                       }).ToList();

            // Agama
            ViewBag.Agama = Enum.GetValues(typeof(Agama))
                                .Cast<Agama>()
                                .Select(e => new
                                {
                                    ID = (int)e,
                                    Name = e.GetType()
                                            .GetField(e.ToString())
                                            .GetCustomAttributes(typeof(DisplayAttribute), false)
                                            .Cast<DisplayAttribute>()
                                            .FirstOrDefault()?.Name ?? e.ToString()
                                }).ToList();

            // Pendidikan
            ViewBag.Pendidikan = Enum.GetValues(typeof(Pendidikan))
                                     .Cast<Pendidikan>()
                                     .Select(e => new
                                     {
                                         ID = (int)e,
                                         Name = e.GetType()
                                                 .GetField(e.ToString())
                                                 .GetCustomAttributes(typeof(DisplayAttribute), false)
                                                 .Cast<DisplayAttribute>()
                                                 .FirstOrDefault()?.Name ?? e.ToString()
                                     }).ToList();

            // Pekerjaan
            ViewBag.Pekerjaan = Enum.GetValues(typeof(Pekerjaan))
                                    .Cast<Pekerjaan>()
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
