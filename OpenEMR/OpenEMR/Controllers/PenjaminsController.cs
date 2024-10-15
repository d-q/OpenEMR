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
    public class PenjaminsController : Controller
    {
        private readonly OpenEMRContext _context;

        public PenjaminsController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: Penjamins
        public async Task<IActionResult> Index()
        {
            return View(await _context.Penjamin.ToListAsync());
        }

        // GET: Penjamins/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penjamin = await _context.Penjamin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (penjamin == null)
            {
                return NotFound();
            }

            return View(penjamin);
        }

        // GET: Penjamins/Create
        public IActionResult Create()
        {
            PopulatePenjaminsDropDownList();
            return View();
        }

        // POST: Penjamins/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NamaPenjamin,StatusPasien,TarifJasaAdministrasi,TarifRumahSakit")] Penjamin penjamin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(penjamin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(penjamin);
        }

        // GET: Penjamins/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penjamin = await _context.Penjamin.FindAsync(id);
            if (penjamin == null)
            {
                return NotFound();
            }

            PopulatePenjaminsDropDownList();
            return View(penjamin);
        }

        // POST: Penjamins/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NamaPenjamin,StatusPasien,TarifJasaAdministrasi,TarifRumahSakit")] Penjamin penjamin)
        {
            if (id != penjamin.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(penjamin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PenjaminExists(penjamin.Id))
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
            return View(penjamin);
        }

        // GET: Penjamins/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var penjamin = await _context.Penjamin
                .FirstOrDefaultAsync(m => m.Id == id);
            if (penjamin == null)
            {
                return NotFound();
            }

            return View(penjamin);
        }

        // POST: Penjamins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var penjamin = await _context.Penjamin.FindAsync(id);
            _context.Penjamin.Remove(penjamin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PenjaminExists(int id)
        {
            return _context.Penjamin.Any(e => e.Id == id);
        }

        private void PopulatePenjaminsDropDownList(object selectedDepartment = null)
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
