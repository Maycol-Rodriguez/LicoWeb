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
    public class VentumsController : Controller
    {
        private readonly BDMaycoholVFinalContext _context;

        public VentumsController(BDMaycoholVFinalContext context)
        {
            _context = context;
        }

        // GET: Ventums
        public async Task<IActionResult> Index()
        {
            var bDMaycoholVFinalContext = _context.Venta.Include(v => v.DniNavigation).Include(v => v.IdempleadoNavigation);
            return View(await bDMaycoholVFinalContext.ToListAsync());
        }

        // GET: Ventums/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.DniNavigation)
                .Include(v => v.IdempleadoNavigation)
                .FirstOrDefaultAsync(m => m.Idventa == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // GET: Ventums/Create
        public IActionResult Create()
        {
            ViewData["Dni"] = new SelectList(_context.Clientes, "Dni", "Dni");
            ViewData["Idempleado"] = new SelectList(_context.Empleados, "Idempleado", "Idempleado");
            return View();
        }

        // POST: Ventums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idventa,Fecha,Dni,Idempleado")] Ventum ventum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Dni"] = new SelectList(_context.Clientes, "Dni", "Dni", ventum.Dni);
            ViewData["Idempleado"] = new SelectList(_context.Empleados, "Idempleado", "Idempleado", ventum.Idempleado);
            return View(ventum);
        }

        // GET: Ventums/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta.FindAsync(id);
            if (ventum == null)
            {
                return NotFound();
            }
            ViewData["Dni"] = new SelectList(_context.Clientes, "Dni", "Dni", ventum.Dni);
            ViewData["Idempleado"] = new SelectList(_context.Empleados, "Idempleado", "Idempleado", ventum.Idempleado);
            return View(ventum);
        }

        // POST: Ventums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Idventa,Fecha,Dni,Idempleado")] Ventum ventum)
        {
            if (id != ventum.Idventa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentumExists(ventum.Idventa))
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
            ViewData["Dni"] = new SelectList(_context.Clientes, "Dni", "Dni", ventum.Dni);
            ViewData["Idempleado"] = new SelectList(_context.Empleados, "Idempleado", "Idempleado", ventum.Idempleado);
            return View(ventum);
        }

        // GET: Ventums/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Venta == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.DniNavigation)
                .Include(v => v.IdempleadoNavigation)
                .FirstOrDefaultAsync(m => m.Idventa == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // POST: Ventums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Venta == null)
            {
                return Problem("Entity set 'BDMaycoholVFinalContext.Venta'  is null.");
            }
            var ventum = await _context.Venta.FindAsync(id);
            if (ventum != null)
            {
                _context.Venta.Remove(ventum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentumExists(string id)
        {
          return (_context.Venta?.Any(e => e.Idventa == id)).GetValueOrDefault();
        }
    }
}
