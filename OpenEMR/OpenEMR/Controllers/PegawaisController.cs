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
    public class PegawaisController : Controller
    {
        private readonly OpenEMRContext _context;

        public PegawaisController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: Pegawais
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Pegawai.ToListAsync());

            var pegawaiList = await _context.Pegawai
                            .Where(p => EF.Property<string>(p, "Discriminator") == "Pegawai")
                            .ToListAsync();
            return View(pegawaiList);
        }

        // GET: Pegawais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _context.Pegawai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pegawai == null)
            {
                return NotFound();
            }

            return View(pegawai);
        }

        // GET: Pegawais/Create
        public IActionResult Create()
        {
            PopulatePegawaisDropDownList();
            return View();
        }

        // POST: Pegawais/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,NIK,TanggalLahir,TempatLahir,JenisKelamin,AlamatRumah,NomorTeleponPribadi,NomorTeleponDarurat,AlamatEmailPribadi,StatusPernikahan")] Pegawai pegawai)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pegawai);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pegawai);
        }

        // GET: Pegawais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _context.Pegawai.FindAsync(id);
            if (pegawai == null)
            {
                return NotFound();
            }

            PopulatePegawaisDropDownList();
            return View(pegawai);
        }

        // POST: Pegawais/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,NIK,TanggalLahir,TempatLahir,JenisKelamin,AlamatRumah,NomorTeleponPribadi,NomorTeleponDarurat,AlamatEmailPribadi,StatusPernikahan")] Pegawai pegawai)
        {
            if (id != pegawai.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pegawai);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PegawaiExists(pegawai.Id))
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
            return View(pegawai);
        }

        // GET: Pegawais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pegawai = await _context.Pegawai
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pegawai == null)
            {
                return NotFound();
            }

            return View(pegawai);
        }

        // POST: Pegawais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pegawai = await _context.Pegawai.FindAsync(id);
            _context.Pegawai.Remove(pegawai);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PegawaiExists(int id)
        {
            return _context.Pegawai.Any(e => e.Id == id);
        }

        private void PopulatePegawaisDropDownList(object selectedDepartment = null)
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
