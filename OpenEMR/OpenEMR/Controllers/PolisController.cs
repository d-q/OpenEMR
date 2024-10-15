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
    public class PolisController : Controller
    {
        private readonly OpenEMRContext _context;

        public PolisController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: Polis
        public async Task<IActionResult> Index()
        {
            return View(await _context.Poli.ToListAsync());
        }

        // GET: Polis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poli = await _context.Poli
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poli == null)
            {
                return NotFound();
            }

            return View(poli);
        }

        // GET: Polis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Polis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NamaPoli")] Poli poli)
        {
            if (ModelState.IsValid)
            {
                _context.Add(poli);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(poli);
        }

        // GET: Polis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poli = await _context.Poli.FindAsync(id);
            if (poli == null)
            {
                return NotFound();
            }
            return View(poli);
        }

        // POST: Polis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NamaPoli")] Poli poli)
        {
            if (id != poli.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(poli);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PoliExists(poli.Id))
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
            return View(poli);
        }

        // GET: Polis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var poli = await _context.Poli
                .FirstOrDefaultAsync(m => m.Id == id);
            if (poli == null)
            {
                return NotFound();
            }

            return View(poli);
        }

        // POST: Polis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var poli = await _context.Poli.FindAsync(id);
            _context.Poli.Remove(poli);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PoliExists(int id)
        {
            return _context.Poli.Any(e => e.Id == id);
        }
    }
}
