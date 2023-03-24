using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GEST.Data;
using GEST.Models;

namespace GEST.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PublicationsController : Controller
    {
        private readonly GESTContext _context;

        public PublicationsController(GESTContext context)
        {
            _context = context;
        }

        // GET: Admin/Publications
        public async Task<IActionResult> Index()
        {
              return View(await _context.Publications.ToListAsync());
        }

        // GET: Admin/Publications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Publications == null)
            {
                return NotFound();
            }

            var publications = await _context.Publications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publications == null)
            {
                return NotFound();
            }

            return View(publications);
        }

        // GET: Admin/Publications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Publications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Authors,Name")] Publications publications)
        {
            if (ModelState.IsValid)
            {
                _context.Add(publications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(publications);
        }

        // GET: Admin/Publications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Publications == null)
            {
                return NotFound();
            }

            var publications = await _context.Publications.FindAsync(id);
            if (publications == null)
            {
                return NotFound();
            }
            return View(publications);
        }

        // POST: Admin/Publications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Authors,Name")] Publications publications)
        {
            if (id != publications.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(publications);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicationsExists(publications.Id))
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
            return View(publications);
        }

        // GET: Admin/Publications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Publications == null)
            {
                return NotFound();
            }

            var publications = await _context.Publications
                .FirstOrDefaultAsync(m => m.Id == id);
            if (publications == null)
            {
                return NotFound();
            }

            return View(publications);
        }

        // POST: Admin/Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Publications == null)
            {
                return Problem("Entity set 'GESTContext.Publications'  is null.");
            }
            var publications = await _context.Publications.FindAsync(id);
            if (publications != null)
            {
                _context.Publications.Remove(publications);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PublicationsExists(int id)
        {
          return _context.Publications.Any(e => e.Id == id);
        }
    }
}
