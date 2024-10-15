using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenEMR.Data;
using OpenEMR.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OpenEMR.Controllers
{
    public class DoktersController : Controller
    {
        private readonly OpenEMRContext _context;

        public DoktersController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: Dokters
        public async Task<IActionResult> Index()
        {
            var openEMRContext = _context.Dokter.Include(d => d.Poli);
            return View(await openEMRContext.ToListAsync());
        }

        // GET: Dokters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokter = await _context.Dokter
                .Include(d => d.Poli)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dokter == null)
            {
                return NotFound();
            }

            return View(dokter);
        }

        // GET: Dokters/Create
        public IActionResult Create()
        {
            PopulateDoktersDropDownList();

            ViewData["PoliId"] = new SelectList(_context.Poli, "Id", "NamaPoli");
            return View();
        }

        // POST: Dokters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomorSIP,TaripPemeriksaan,PoliId,Id,FirstName,LastName,NIK,TanggalLahir,TempatLahir,JenisKelamin,AlamatRumah,NomorTeleponPribadi,NomorTeleponDarurat,AlamatEmailPribadi,StatusPernikahan")] Dokter dokter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dokter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PoliId"] = new SelectList(_context.Poli, "Id", "NamaPoli", dokter.PoliId);
            return View(dokter);
        }

        // GET: Dokters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokter = await _context.Dokter.FindAsync(id);
            if (dokter == null)
            {
                return NotFound();
            }

            PopulateDoktersDropDownList();
            ViewData["PoliId"] = new SelectList(_context.Poli, "Id", "NamaPoli", dokter.PoliId);
            return View(dokter);
        }

        // POST: Dokters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NomorSIP,TaripPemeriksaan,PoliId,Id,FirstName,LastName,NIK,TanggalLahir,TempatLahir,JenisKelamin,AlamatRumah,NomorTeleponPribadi,NomorTeleponDarurat,AlamatEmailPribadi,StatusPernikahan")] Dokter dokter)
        {
            if (id != dokter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dokter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DokterExists(dokter.Id))
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
            ViewData["PoliId"] = new SelectList(_context.Poli, "Id", "NamaPoli", dokter.PoliId);
            return View(dokter);
        }

        // GET: Dokters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dokter = await _context.Dokter
                .Include(d => d.Poli)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dokter == null)
            {
                return NotFound();
            }

            return View(dokter);
        }

        // POST: Dokters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dokter = await _context.Dokter.FindAsync(id);
            _context.Dokter.Remove(dokter);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DokterExists(int id)
        {
            return _context.Dokter.Any(e => e.Id == id);
        }

        private void PopulateDoktersDropDownList(object selectedDepartment = null)
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
        }
    }
}
