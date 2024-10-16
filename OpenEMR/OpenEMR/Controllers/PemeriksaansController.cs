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
    public class PemeriksaansController : Controller
    {
        private readonly OpenEMRContext _context;

        public PemeriksaansController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: Pemeriksaans
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pemeriksaan.ToListAsync());
        }

        // GET: Pemeriksaans/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemeriksaan = await _context.Pemeriksaan
                .FirstOrDefaultAsync(m => m.KodeTarif == id);
            if (pemeriksaan == null)
            {
                return NotFound();
            }

            return View(pemeriksaan);
        }

        // GET: Pemeriksaans/Create
        public IActionResult Create()
        {
            PopulatePemeriksaansDropDownList();
            return View();
        }

        // POST: Pemeriksaans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KodeTarif,NamaPemeriksaan,Deskripsi,JenisPemeriksaan,KategoriPemeriksaan,Tarif")] Pemeriksaan pemeriksaan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pemeriksaan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pemeriksaan);
        }

        // GET: Pemeriksaans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemeriksaan = await _context.Pemeriksaan.FindAsync(id);
            if (pemeriksaan == null)
            {
                return NotFound();
            }

            PopulatePemeriksaansDropDownList();
            return View(pemeriksaan);
        }

        // POST: Pemeriksaans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KodeTarif,NamaPemeriksaan,Deskripsi,JenisPemeriksaan,KategoriPemeriksaan,Tarif")] Pemeriksaan pemeriksaan)
        {
            if (id != pemeriksaan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pemeriksaan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PemeriksaanExists(pemeriksaan.Id))
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
            return View(pemeriksaan);
        }

        // GET: Pemeriksaans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pemeriksaan = await _context.Pemeriksaan
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pemeriksaan == null)
            {
                return NotFound();
            }

            return View(pemeriksaan);
        }

        // POST: Pemeriksaans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var pemeriksaan = await _context.Pemeriksaan.FindAsync(id);
            _context.Pemeriksaan.Remove(pemeriksaan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PemeriksaanExists(int? id)
        {
            return _context.Pemeriksaan.Any(e => e.Id == id);
        }

        private void PopulatePemeriksaansDropDownList(object selectedDepartment = null)
        {
            ViewBag.JenisPemeriksaan = Enum.GetValues(typeof(JenisPemeriksaan))
                       .Cast<JenisPemeriksaan>()
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
