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
    public class ParkTypesController : Controller
    {
        private readonly BcParksMvcContext _context;

        public ParkTypesController(BcParksMvcContext context)
        {
            _context = context;
        }

        // GET: ParkTypes
        public async Task<IActionResult> Index(string sortOrder)
        {
            // sorting
            ViewData["NameSortParam"] = sortOrder == "name_desc" ? "name_asc" : "name_desc";
            ViewData["AbbreviationSortParam"] = sortOrder == "abbreviation_desc" ? "abbreviation_asc" : "abbreviation_desc";
            var parkTypes = from pt in _context.ParkType
                            select pt;
            parkTypes = sortOrder switch
            {
                "name_asc" => parkTypes.OrderBy(pt => pt.Name),
                "name_desc" => parkTypes.OrderByDescending(pt => pt.Name),
                "abbreviation_asc" => parkTypes.OrderBy(pt => pt.Abbreviation),
                "abbreviation_desc" => parkTypes.OrderByDescending(pt => pt.Abbreviation),
                _ => parkTypes.OrderBy(pt => pt.Name)
            };

            return View(await parkTypes.AsNoTracking().ToListAsync());
        }

        // GET: ParkTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ParkType == null)
            {
                return NotFound();
            }

            var parkType = await _context.ParkType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkType == null)
            {
                return NotFound();
            }

            return View(parkType);
        }

        // GET: ParkTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ParkTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Abbreviation")] ParkType parkType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parkType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parkType);
        }

        // GET: ParkTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ParkType == null)
            {
                return NotFound();
            }

            var parkType = await _context.ParkType.FindAsync(id);
            if (parkType == null)
            {
                return NotFound();
            }
            return View(parkType);
        }

        // POST: ParkTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Abbreviation")] ParkType parkType)
        {
            if (id != parkType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parkType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParkTypeExists(parkType.Id))
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
            return View(parkType);
        }

        // GET: ParkTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ParkType == null)
            {
                return NotFound();
            }

            var parkType = await _context.ParkType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parkType == null)
            {
                return NotFound();
            }

            return View(parkType);
        }

        // POST: ParkTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ParkType == null)
            {
                return Problem("Entity set 'BcParksMvcContext.ParkType'  is null.");
            }
            var parkType = await _context.ParkType.FindAsync(id);
            if (parkType != null)
            {
                _context.ParkType.Remove(parkType);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParkTypeExists(int id)
        {
            return (_context.ParkType?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
