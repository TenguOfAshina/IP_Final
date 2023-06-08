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
    public class SoftwaresController : Controller
    {
        private readonly DatabaseContext _context;

        public SoftwaresController(DatabaseContext context)
        {
            _context = context;
        }

        //public async Task<IActionResult> Home()
        //{
        //    return _context.Softwares != null ?
        //                  View(await _context.Softwares.ToListAsync()) :
        //                  Problem("Entity set 'DatabaseContext.Softwares'  is null.");
        //}

        public async Task<IActionResult> Home()
        {
            return _context.Softwares != null ?
                          View(await _context.Softwares.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.Softwares'  is null.");
        }

        // GET: Softwares
        public async Task<IActionResult> Index()
        {
              return _context.Softwares != null ? 
                          View(await _context.Softwares.ToListAsync()) :
                          Problem("Entity set 'DatabaseContext.Softwares'  is null.");
        }

        // GET: Softwares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Softwares == null)
            {
                return NotFound();
            }

            var software = await _context.Softwares
                .FirstOrDefaultAsync(m => m.app_id == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // GET: Softwares/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Software software)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                _context.Softwares.Add(software);
                _context.SaveChanges();
                TempData["msg"] = "Added successfully";
                return RedirectToAction("Create");

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Could not be added!!!";
                return View();
            }
        }

        // GET: Softwares/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Softwares == null)
            {
                return NotFound();
            }

            var software = await _context.Softwares.FindAsync(id);
            if (software == null)
            {
                return NotFound();
            }
            return View(software);
        }

        // POST: Softwares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("app_id,app_name,app_version,app_description,app_size,app_owner,app_image_url,app_install_count, cat_code, lang_code, os_code")] Software software)
        {
            if (id != software.app_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(software);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SoftwareExists(software.app_id))
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
            return View(software);
        }

        // GET: Softwares/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Softwares == null)
            {
                return NotFound();
            }

            var software = await _context.Softwares
                .FirstOrDefaultAsync(m => m.app_id == id);
            if (software == null)
            {
                return NotFound();
            }

            return View(software);
        }

        // POST: Softwares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Softwares == null)
            {
                return Problem("Entity set 'DatabaseContext.Softwares'  is null.");
            }
            var software = await _context.Softwares.FindAsync(id);
            if (software != null)
            {
                _context.Softwares.Remove(software);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SoftwareExists(int id)
        {
          return (_context.Softwares?.Any(e => e.app_id == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> app(int? id)
        {
            if (id == null || _context.Softwares == null)
            {
                return NotFound();
            }

            var softwaresTable = await _context.Softwares
                .FirstOrDefaultAsync(m => m.app_id == id);
            if (softwaresTable == null)
            {
                return NotFound();
            }

            return View(softwaresTable);
        }

        //[HttpPost]
        //public FileResult DownloadApp(Software software)
        //{
            
        //    string filepath = "C:/Users/User/Desktop/folder/" + software.app_name + ".rar";
        //    byte[] fileBytes = System.IO.File.ReadAllBytes(@filepath);
        //    string fileName = software.app_name + ".rar";
        //    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        //}

        
        public FileResult DownloadApp(int id, string name)
        {

            string filepath = "C:/Users/User/Desktop/folder/" + id.ToString() + ".rar";
            byte[] fileBytes = System.IO.File.ReadAllBytes(@filepath);
            string fileName = name + ".rar";
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }


    }
}
