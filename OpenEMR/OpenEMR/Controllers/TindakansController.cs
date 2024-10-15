using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenEMR.Data;
using OpenEMR.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OpenEMR.Controllers
{
    public class TindakansController : Controller
    {
        private readonly OpenEMRContext _context;

        public TindakansController(OpenEMRContext context)
        {
            _context = context;
        }

        // GET: Tindakans
        public async Task<IActionResult> Index()
        {
            var openEMRContext = _context.Tindakan.Include(t => t.Kunjungan).Include(t => t.Pemeriksa).Include(t => t.TindakanMedis);
            return View(await openEMRContext.ToListAsync());
        }

        // GET: Tindakans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tindakan = await _context.Tindakan
                .Include(t => t.Kunjungan)
                .Include(t => t.Pemeriksa)
                .Include(t => t.TindakanMedis)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tindakan == null)
            {
                return NotFound();
            }

            return View(tindakan);
        }

        // GET: Tindakans/Create
        public IActionResult Create()
        {
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "PasienDanNomorRegis");
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "FirstName");
            ViewData["PemeriksaanId"] = new SelectList(_context.Pemeriksaan, "Id", "NamaPemeriksaan");
            return View();
        }

        // POST: Tindakans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PegawaiId,KunjunganId,PemeriksaanId,WaktuPemeriksaan")] Tindakan tindakan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tindakan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "PasienDanNomorRegis", tindakan.KunjunganId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "FirstName", tindakan.PegawaiId);
            ViewData["PemeriksaanId"] = new SelectList(_context.Pemeriksaan, "Id", "NamaPemeriksaan", tindakan.PemeriksaanId);
            return View(tindakan);
        }

        // GET: Tindakans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tindakan = await _context.Tindakan.FindAsync(id);
            if (tindakan == null)
            {
                return NotFound();
            }
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "PasienDanNomorRegis", tindakan.KunjunganId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "FirstName", tindakan.PegawaiId);
            ViewData["PemeriksaanId"] = new SelectList(_context.Pemeriksaan, "Id", "NamaPemeriksaan", tindakan.PemeriksaanId);
            return View(tindakan);
        }

        // POST: Tindakans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PegawaiId,KunjunganId,PemeriksaanId,WaktuPemeriksaan")] Tindakan tindakan)
        {
            if (id != tindakan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tindakan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TindakanExists(tindakan.Id))
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
            ViewData["KunjunganId"] = new SelectList(_context.Kunjungan, "Id", "PasienDanNomorRegis", tindakan.KunjunganId);
            ViewData["PegawaiId"] = new SelectList(_context.Pegawai, "Id", "FirstName", tindakan.PegawaiId);
            ViewData["PemeriksaanId"] = new SelectList(_context.Pemeriksaan, "Id", "NamaPemeriksaan", tindakan.PemeriksaanId);
            return View(tindakan);
        }

        // GET: Tindakans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tindakan = await _context.Tindakan
                .Include(t => t.Kunjungan)
                .Include(t => t.Pemeriksa)
                .Include(t => t.TindakanMedis)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tindakan == null)
            {
                return NotFound();
            }

            return View(tindakan);
        }

        // POST: Tindakans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tindakan = await _context.Tindakan.FindAsync(id);
            _context.Tindakan.Remove(tindakan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TindakanExists(int id)
        {
            return _context.Tindakan.Any(e => e.Id == id);
        }
    }
}
