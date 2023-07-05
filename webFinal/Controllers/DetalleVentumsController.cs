using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using webFinal.Models;

namespace webFinal.Controllers
{
    public class DetalleVentumsController : Controller
    {
        private readonly BDMaycoholVFinalContext _context;

        public DetalleVentumsController(BDMaycoholVFinalContext context)
        {
            _context = context;
        }

        // GET: DetalleVentums
        public async Task<IActionResult> Index()
        {
            var bDMaycoholVFinalContext = _context.DetalleVenta.Include(d => d.IdproductoNavigation).Include(d => d.IdventaNavigation);
            return View(await bDMaycoholVFinalContext.ToListAsync());
        }

        // GET: DetalleVentums/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVentum = await _context.DetalleVenta
                .Include(d => d.IdproductoNavigation)
                .Include(d => d.IdventaNavigation)
                .FirstOrDefaultAsync(m => m.Iddetalle == id);
            if (detalleVentum == null)
            {
                return NotFound();
            }

            return View(detalleVentum);
        }

        // GET: DetalleVentums/Create
        public IActionResult Create()
        {
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto");
            ViewData["Idventa"] = new SelectList(_context.Venta, "Idventa", "Idventa");
            return View();
        }

        // POST: DetalleVentums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Iddetalle,Hora,Idventa,Idproducto,Cantidad")] DetalleVentum detalleVentum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detalleVentum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto", detalleVentum.Idproducto);
            ViewData["Idventa"] = new SelectList(_context.Venta, "Idventa", "Idventa", detalleVentum.Idventa);
            return View(detalleVentum);
        }

        // GET: DetalleVentums/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVentum = await _context.DetalleVenta.FindAsync(id);
            if (detalleVentum == null)
            {
                return NotFound();
            }
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto", detalleVentum.Idproducto);
            ViewData["Idventa"] = new SelectList(_context.Venta, "Idventa", "Idventa", detalleVentum.Idventa);
            return View(detalleVentum);
        }

        // POST: DetalleVentums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Iddetalle,Hora,Idventa,Idproducto,Cantidad")] DetalleVentum detalleVentum)
        {
            if (id != detalleVentum.Iddetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detalleVentum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetalleVentumExists(detalleVentum.Iddetalle))
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
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Idproducto", detalleVentum.Idproducto);
            ViewData["Idventa"] = new SelectList(_context.Venta, "Idventa", "Idventa", detalleVentum.Idventa);
            return View(detalleVentum);
        }

        // GET: DetalleVentums/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.DetalleVenta == null)
            {
                return NotFound();
            }

            var detalleVentum = await _context.DetalleVenta
                .Include(d => d.IdproductoNavigation)
                .Include(d => d.IdventaNavigation)
                .FirstOrDefaultAsync(m => m.Iddetalle == id);
            if (detalleVentum == null)
            {
                return NotFound();
            }

            return View(detalleVentum);
        }

        // POST: DetalleVentums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.DetalleVenta == null)
            {
                return Problem("Entity set 'BDMaycoholVFinalContext.DetalleVenta'  is null.");
            }
            var detalleVentum = await _context.DetalleVenta.FindAsync(id);
            if (detalleVentum != null)
            {
                _context.DetalleVenta.Remove(detalleVentum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetalleVentumExists(string id)
        {
          return (_context.DetalleVenta?.Any(e => e.Iddetalle == id)).GetValueOrDefault();
        }
    }
}
