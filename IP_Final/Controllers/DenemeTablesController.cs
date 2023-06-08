using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IP_Final.Models.Domain;

namespace IP_Final.Controllers
{
    public class DenemeTablesController : Controller
    {
        private readonly DatabaseContext _context;

        public DenemeTablesController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult AddDeneme()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDeneme(DenemeTable deneme)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.DenemeTables.Add(deneme);
                _context.SaveChanges();
                TempData["msg"] = "Added successfully";
                return RedirectToAction("AddDeneme");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not added!!!";
                return View();
            }

        }

        // GET: DenemeTables
        public async Task<IActionResult> Index()
        {
              return _context.DenemeTables != null ? 
                          View(await _context.DenemeTables.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.DenemeTables'  is null.");
        }

        // GET: DenemeTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.DenemeTables == null)
            {
                return NotFound();
            }

            var denemeTable = await _context.DenemeTables
                .FirstOrDefaultAsync(m => m.deneme_id == id);
            if (denemeTable == null)
            {
                return NotFound();
            }

            return View(denemeTable);
        }

        // GET: DenemeTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DenemeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("deneme_id,deneme_name")] DenemeTable denemeTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(denemeTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(denemeTable);
        }

        // GET: DenemeTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.DenemeTables == null)
            {
                return NotFound();
            }

            var denemeTable = await _context.DenemeTables.FindAsync(id);
            if (denemeTable == null)
            {
                return NotFound();
            }
            return View(denemeTable);
        }

        // POST: DenemeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("deneme_id,deneme_name")] DenemeTable denemeTable)
        {
            if (id != denemeTable.deneme_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(denemeTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DenemeTableExists(denemeTable.deneme_id))
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
            return View(denemeTable);
        }

        // GET: DenemeTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.DenemeTables == null)
            {
                return NotFound();
            }

            var denemeTable = await _context.DenemeTables
                .FirstOrDefaultAsync(m => m.deneme_id == id);
            if (denemeTable == null)
            {
                return NotFound();
            }

            return View(denemeTable);
        }

        // POST: DenemeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.DenemeTables == null)
            {
                return Problem("Entity set 'DatabaseContext.DenemeTables'  is null.");
            }
            var denemeTable = await _context.DenemeTables.FindAsync(id);
            if (denemeTable != null)
            {
                _context.DenemeTables.Remove(denemeTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DenemeTableExists(int id)
        {
          return (_context.DenemeTables?.Any(e => e.deneme_id == id)).GetValueOrDefault();
        }
    }
}
