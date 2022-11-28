using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GestaoFinanceira.Data;
using GestaoFinanceira.Models;

namespace GestaoFinanceira
{
    public class RegistroesController : Controller
    {
        private readonly GestaoFinanceiraContext _context;

        public RegistroesController(GestaoFinanceiraContext context)
        {
            _context = context;
        }

        // GET: Registroes
        public async Task<IActionResult> Index()
        {
            var gestaoFinanceiraContext = _context.Registro.Include(r => r.Tipo);
            return View(await gestaoFinanceiraContext.ToListAsync());
        }

        // GET: Registroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Registro == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro
                .Include(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // GET: Registroes/Create
        public IActionResult Create()
        {
            ViewData["TipoId"] = new SelectList(_context.Tipo, "TipoId", "Nome");
            return View();
        }

        // POST: Registroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,Data,TipoId")] Registro registro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TipoId"] = new SelectList(_context.Tipo, "TipoId", "Nome", registro.TipoId);
            return View(registro);
        }

        // GET: Registroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Registro == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro.FindAsync(id);
            if (registro == null)
            {
                return NotFound();
            }
            ViewData["TipoId"] = new SelectList(_context.Tipo, "TipoId", "Nome", registro.TipoId);
            return View(registro);
        }

        // POST: Registroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,Data,TipoId")] Registro registro)
        {
            if (id != registro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistroExists(registro.Id))
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
            ViewData["TipoId"] = new SelectList(_context.Tipo, "TipoId", "Nome", registro.TipoId);
            return View(registro);
        }

        // GET: Registroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Registro == null)
            {
                return NotFound();
            }

            var registro = await _context.Registro
                .Include(r => r.Tipo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (registro == null)
            {
                return NotFound();
            }

            return View(registro);
        }

        // POST: Registroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Registro == null)
            {
                return Problem("Entity set 'GestaoFinanceiraContext.Registro'  is null.");
            }
            var registro = await _context.Registro.FindAsync(id);
            if (registro != null)
            {
                _context.Registro.Remove(registro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistroExists(int id)
        {
          return _context.Registro.Any(e => e.Id == id);
        }
    }
}
