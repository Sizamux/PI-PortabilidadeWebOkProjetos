using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PI_PorrtabilidadeWebOkPrrojetos.Data;
using PI_PorrtabilidadeWebOkPrrojetos.Models;

namespace PI_PorrtabilidadeWebOkPrrojetos.Controllers
{
    public class OrdRecebimentoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdRecebimentoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdRecebimentoes
        public async Task<IActionResult> Index()
        {
              return _context.OrdRecebimento != null ? 
                          View(await _context.OrdRecebimento.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.OrdRecebimento'  is null.");
        }

        // GET: OrdRecebimentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdRecebimento == null)
            {
                return NotFound();
            }

            var ordRecebimento = await _context.OrdRecebimento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordRecebimento == null)
            {
                return NotFound();
            }

            return View(ordRecebimento);
        }

        // GET: OrdRecebimentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdRecebimentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroNf,Status,DataDeRecebimento,DataDeCriacao,UltimaModificacao")] OrdRecebimento ordRecebimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordRecebimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordRecebimento);
        }

        // GET: OrdRecebimentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdRecebimento == null)
            {
                return NotFound();
            }

            var ordRecebimento = await _context.OrdRecebimento.FindAsync(id);
            if (ordRecebimento == null)
            {
                return NotFound();
            }
            return View(ordRecebimento);
        }

        // POST: OrdRecebimentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroNf,Status,DataDeRecebimento,DataDeCriacao,UltimaModificacao")] OrdRecebimento ordRecebimento)
        {
            if (id != ordRecebimento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordRecebimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdRecebimentoExists(ordRecebimento.Id))
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
            return View(ordRecebimento);
        }

        // GET: OrdRecebimentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdRecebimento == null)
            {
                return NotFound();
            }

            var ordRecebimento = await _context.OrdRecebimento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordRecebimento == null)
            {
                return NotFound();
            }

            return View(ordRecebimento);
        }

        // POST: OrdRecebimentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdRecebimento == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OrdRecebimento'  is null.");
            }
            var ordRecebimento = await _context.OrdRecebimento.FindAsync(id);
            if (ordRecebimento != null)
            {
                _context.OrdRecebimento.Remove(ordRecebimento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdRecebimentoExists(int id)
        {
          return (_context.OrdRecebimento?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
