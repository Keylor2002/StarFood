using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StarFood.Data;
using StarFood.Models;

namespace StarFood.Controllers
{
    public class PlatillosController : Controller
    {
        private readonly StarfoodContext _context;

        public PlatillosController(StarfoodContext context)
        {
            _context = context;
        }

        // GET: Platillos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Platillos.ToListAsync());
        }

        // GET: Platillos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Platillos = await _context.Platillos
                .FirstOrDefaultAsync(m => m.IDPlatillo == id);
            if (Platillos == null)
            {
                return NotFound();
            }

            return View(Platillos);
        }

        // GET: Platillos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Platillos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDPlatillo,Empresa,Contacto,Nombre")] Platillo Platillos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Platillos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Platillos);
        }

        // GET: Platillos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Platillos = await _context.Platillos.FindAsync(id);
            if (Platillos == null)
            {
                return NotFound();
            }
            return View(Platillos);
        }

        // POST: Platillos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDPlatillo,Empresa,Contacto,Nombre")] Platillo Platillos)
        {
            if (id != Platillos.IDPlatillo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Platillos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlatillosExists(Platillos.IDPlatillo))
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
            return View(Platillos);
        }

        // GET: Platillos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Platillos = await _context.Platillos
                .FirstOrDefaultAsync(m => m.IDPlatillo == id);
            if (Platillos == null)
            {
                return NotFound();
            }

            return View(Platillos);
        }

        // POST: Platillos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Platillos = await _context.Platillos.FindAsync(id);
            if (Platillos != null)
            {
                _context.Platillos.Remove(Platillos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlatillosExists(int id)
        {
            return _context.Platillos.Any(e => e.IDPlatillo == id);
        }
    }
}
