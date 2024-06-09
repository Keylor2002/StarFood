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
    public class FacturasController : Controller
    {
        private readonly StarfoodContext _context;

        public FacturasController(StarfoodContext context)
        {
            _context = context;
        }

        // GET: Facturas
        public async Task<IActionResult> Index()
        {
            var starfoodContext = _context.Facturas.Include(f => f.MetodoPago).Include(f => f.Pedido);
            return View(await starfoodContext.ToListAsync());
        }

        // GET: Facturas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.MetodoPago)
                .Include(f => f.Pedido)
                .FirstOrDefaultAsync(m => m.IDFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // GET: Facturas/Create
        public IActionResult Create()
        {
            ViewData["IDMetodoPago"] = new SelectList(_context.MetodosPago, "IDMetodoPago", "NombreMetodoPago");
            ViewData["IDPedido"] = new SelectList(_context.Pedidos, "IDPedido", "IDPedido");
            return View();
        }

        // POST: Facturas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDFactura,IDPedido,FechaVenta,TotalVenta,IDMetodoPago,CantidadPago,CantidadCambio")] Factura factura)
        {
            if (ModelState.IsValid)
            {
                _context.Add(factura);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDMetodoPago"] = new SelectList(_context.MetodosPago, "IDMetodoPago", "NombreMetodoPago", factura.IDMetodoPago);
            ViewData["IDPedido"] = new SelectList(_context.Pedidos, "IDPedido", "IDPedido", factura.IDPedido);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas.FindAsync(id);
            if (factura == null)
            {
                return NotFound();
            }
            ViewData["IDMetodoPago"] = new SelectList(_context.MetodosPago, "IDMetodoPago", "NombreMetodoPago", factura.IDMetodoPago);
            ViewData["IDPedido"] = new SelectList(_context.Pedidos, "IDPedido", "IDPedido", factura.IDPedido);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDFactura,IDPedido,FechaVenta,TotalVenta,IDMetodoPago,CantidadPago,CantidadCambio")] Factura factura)
        {
            if (id != factura.IDFactura)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(factura);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaExists(factura.IDFactura))
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
            ViewData["IDMetodoPago"] = new SelectList(_context.MetodosPago, "IDMetodoPago", "NombreMetodoPago", factura.IDMetodoPago);
            ViewData["IDPedido"] = new SelectList(_context.Pedidos, "IDPedido", "IDPedido", factura.IDPedido);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var factura = await _context.Facturas
                .Include(f => f.MetodoPago)
                .Include(f => f.Pedido)
                .FirstOrDefaultAsync(m => m.IDFactura == id);
            if (factura == null)
            {
                return NotFound();
            }

            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var factura = await _context.Facturas.FindAsync(id);
            if (factura != null)
            {
                _context.Facturas.Remove(factura);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaExists(int id)
        {
            return _context.Facturas.Any(e => e.IDFactura == id);
        }
    }
}
