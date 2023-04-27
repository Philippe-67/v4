using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using v4.Data;
using v4.Models;

namespace v4.Controllers
{
    public class InterventionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InterventionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Interventions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Interventions.Include(i => i.Voiture);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Interventions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Interventions == null)
            {
                return NotFound();
            }

            var interventions = await _context.Interventions
                .Include(i => i.Voiture)
                .FirstOrDefaultAsync(m => m.InterventionsId == id);
            if (interventions == null)
            {
                return NotFound();
            }

            return View(interventions);
        }

        // GET: Interventions/Create
        public IActionResult Create()
        {
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "VoitureId", "VoitureId");
            return View();
        }

        // POST: Interventions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterventionsId,VoitureId")] Interventions interventions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interventions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "VoitureId", "VoitureId", interventions.VoitureId);
            return View(interventions);
        }

        // GET: Interventions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Interventions == null)
            {
                return NotFound();
            }

            var interventions = await _context.Interventions.FindAsync(id);
            if (interventions == null)
            {
                return NotFound();
            }
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "VoitureId", "VoitureId", interventions.VoitureId);
            return View(interventions);
        }

        // POST: Interventions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterventionsId,VoitureId")] Interventions interventions)
        {
            if (id != interventions.InterventionsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interventions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterventionsExists(interventions.InterventionsId))
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
            ViewData["VoitureId"] = new SelectList(_context.Voitures, "VoitureId", "VoitureId", interventions.VoitureId);
            return View(interventions);
        }

        // GET: Interventions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Interventions == null)
            {
                return NotFound();
            }

            var interventions = await _context.Interventions
                .Include(i => i.Voiture)
                .FirstOrDefaultAsync(m => m.InterventionsId == id);
            if (interventions == null)
            {
                return NotFound();
            }

            return View(interventions);
        }

        // POST: Interventions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Interventions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Interventions'  is null.");
            }
            var interventions = await _context.Interventions.FindAsync(id);
            if (interventions != null)
            {
                _context.Interventions.Remove(interventions);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterventionsExists(int id)
        {
          return (_context.Interventions?.Any(e => e.InterventionsId == id)).GetValueOrDefault();
        }
    }
}
