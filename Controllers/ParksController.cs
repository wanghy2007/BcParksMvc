using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BcParksMvc.Models;

namespace BcParksMvc.Controllers
{
    public class ParksController : Controller
    {
        private readonly BcParksMvcContext _context;

        public ParksController(BcParksMvcContext context)
        {
            _context = context;
        }

        // GET: Parks
        public async Task<IActionResult> Index()
        {
              return _context.Park != null ? 
                          View(await _context.Park.ToListAsync()) :
                          Problem("Entity set 'BcParksMvcContext.Park'  is null.");
        }

        // GET: Parks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Park == null)
            {
                return NotFound();
            }

            var park = await _context.Park
                .FirstOrDefaultAsync(m => m.Id == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // GET: Parks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,AreaHa,AreaAcres,EstablishedYear")] Park park)
        {
            if (ModelState.IsValid)
            {
                _context.Add(park);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(park);
        }

        // GET: Parks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Park == null)
            {
                return NotFound();
            }

            var park = await _context.Park.FindAsync(id);
            if (park == null)
            {
                return NotFound();
            }
            return View(park);
        }

        // POST: Parks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,AreaHa,AreaAcres,EstablishedYear")] Park park)
        {
            if (id != park.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(park);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkExists(park.Id))
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
            return View(park);
        }

        // GET: Parks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Park == null)
            {
                return NotFound();
            }

            var park = await _context.Park
                .FirstOrDefaultAsync(m => m.Id == id);
            if (park == null)
            {
                return NotFound();
            }

            return View(park);
        }

        // POST: Parks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Park == null)
            {
                return Problem("Entity set 'BcParksMvcContext.Park'  is null.");
            }
            var park = await _context.Park.FindAsync(id);
            if (park != null)
            {
                _context.Park.Remove(park);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkExists(int id)
        {
          return (_context.Park?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
