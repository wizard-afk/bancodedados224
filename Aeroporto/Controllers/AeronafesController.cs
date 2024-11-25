using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Aeroporto.Models;

namespace Aeroporto.Controllers
{
    public class AeronafesController : Controller
    {
        private AeroportoContext _context;

        public AeronafesController(AeroportoContext context)
        {
            _context = context;
        }

        // GET: Aeronafes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aeronaves.ToListAsync());
        }

        // GET: Aeronafes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeronafe = await _context.Aeronaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aeronafe == null)
            {
                return NotFound();
            }

            return View(aeronafe);
        }

        // GET: Aeronafes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aeronafes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,NumeroPoltronas")] Aeronafe aeronafe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aeronafe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aeronafe);
        }

        // GET: Aeronafes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeronafe = await _context.Aeronaves.FindAsync(id);
            if (aeronafe == null)
            {
                return NotFound();
            }
            return View(aeronafe);
        }

        // POST: Aeronafes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,NumeroPoltronas")] Aeronafe aeronafe)
        {
            if (id != aeronafe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aeronafe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AeronafeExists(aeronafe.Id))
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
            return View(aeronafe);
        }

        // GET: Aeronafes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aeronafe = await _context.Aeronaves
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aeronafe == null)
            {
                return NotFound();
            }

            return View(aeronafe);
        }

        // POST: Aeronafes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aeronafe = await _context.Aeronaves.FindAsync(id);
            if (aeronafe != null)
            {
                _context.Aeronaves.Remove(aeronafe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AeronafeExists(int id)
        {
            return _context.Aeronaves.Any(e => e.Id == id);
        }
    }
}
