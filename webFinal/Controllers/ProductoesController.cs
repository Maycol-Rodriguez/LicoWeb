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
    public class ProductoesController : Controller
    {
        private readonly BDMaycoholVFinalContext _context;

        public ProductoesController(BDMaycoholVFinalContext context)
        {
            _context = context;
        }

        // GET: Productoes
        public async Task<IActionResult> Index()
        {
            var bDMaycoholVFinalContext = _context.Productos.Include(p => p.IdcategoriaNavigation).Include(p => p.RucNavigation);
            return View(await bDMaycoholVFinalContext.ToListAsync());
        }

        public IActionResult CatalogPro()
        {
            var productos = _context.Productos.ToList(); // Obtén los productos desde la base de datos
            return View(productos); // Retorna la vista "CatalogPro" con la lista de productos como modelo
        }

       




        // GET: Productoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdcategoriaNavigation)
                .Include(p => p.RucNavigation)
                .FirstOrDefaultAsync(m => m.Idproducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productoes/Create
        public IActionResult Create()
        {
            ViewData["Idcategoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria");
            ViewData["Ruc"] = new SelectList(_context.Proveedors, "Ruc", "Ruc");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idproducto,NombreProd,PrecioVenta,Stock,Imagen,Ruc,Idcategoria")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcategoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria", producto.Idcategoria);
            ViewData["Ruc"] = new SelectList(_context.Proveedors, "Ruc", "Ruc", producto.Ruc);
            return View(producto);
        }

        // GET: Productoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            ViewData["Idcategoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria", producto.Idcategoria);
            ViewData["Ruc"] = new SelectList(_context.Proveedors, "Ruc", "Ruc", producto.Ruc);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Idproducto,NombreProd,PrecioVenta,Stock,Imagen,Ruc,Idcategoria")] Producto producto)
        {
            if (id != producto.Idproducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(producto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(producto.Idproducto))
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
            ViewData["Idcategoria"] = new SelectList(_context.Categoria, "Idcategoria", "Idcategoria", producto.Idcategoria);
            ViewData["Ruc"] = new SelectList(_context.Proveedors, "Ruc", "Ruc", producto.Ruc);
            return View(producto);
        }

        // GET: Productoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Productos == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.IdcategoriaNavigation)
                .Include(p => p.RucNavigation)
                .FirstOrDefaultAsync(m => m.Idproducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Productos == null)
            {
                return Problem("Entity set 'BDMaycoholVFinalContext.Productos'  is null.");
            }
            var producto = await _context.Productos.FindAsync(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(string id)
        {
          return (_context.Productos?.Any(e => e.Idproducto == id)).GetValueOrDefault();
        }
    }
}
