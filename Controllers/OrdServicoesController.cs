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
    public class OrdServicoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdServicoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: OrdServicoes
        public async Task<IActionResult> Index()
        {
              return _context.OrdServico != null ? 
                          View(await _context.OrdServico.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.OrdServico'  is null.");
        }

        // GET: OrdServicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OrdServico == null)
            {
                return NotFound();
            }

            var ordServico = await _context.OrdServico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordServico == null)
            {
                return NotFound();
            }

            return View(ordServico);
        }

        // GET: OrdServicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrdServicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroPo,NomeOperadora,DescricaoPo,FaseAtual,DataDeCriacao,UltimaModificacao")] OrdServico ordServico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordServico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ordServico);
        }

        // GET: OrdServicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OrdServico == null)
            {
                return NotFound();
            }

            var ordServico = await _context.OrdServico.FindAsync(id);
            if (ordServico == null)
            {
                return NotFound();
            }
            return View(ordServico);
        }

        // POST: OrdServicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NumeroPo,NomeOperadora,DescricaoPo,FaseAtual,DataDeCriacao,UltimaModificacao")] OrdServico ordServico)
        {
            if (id != ordServico.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordServico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdServicoExists(ordServico.Id))
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
            return View(ordServico);
        }

        // GET: OrdServicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OrdServico == null)
            {
                return NotFound();
            }

            var ordServico = await _context.OrdServico
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordServico == null)
            {
                return NotFound();
            }

            return View(ordServico);
        }

        // POST: OrdServicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OrdServico == null)
            {
                return Problem("Entity set 'ApplicationDbContext.OrdServico'  is null.");
            }
            var ordServico = await _context.OrdServico.FindAsync(id);
            if (ordServico != null)
            {
                _context.OrdServico.Remove(ordServico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdServicoExists(int id)
        {
          return (_context.OrdServico?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
