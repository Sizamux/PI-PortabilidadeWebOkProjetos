using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PI_PorrtabilidadeWebOkPrrojetos.Data;
using PI_PorrtabilidadeWebOkPrrojetos.Models;

namespace PI_PorrtabilidadeWebOkPrrojetos.Controllers
{
    [Authorize]//Anotação Identity
    public class ItnServRecsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItnServRecsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ItnServRecs
        public async Task<IActionResult> Index()
        {
              return _context.ItnServRec != null ? 
                          View(await _context.ItnServRec.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ItnServRec'  is null.");
        }

        // GET: ItnServRecs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ItnServRec == null)
            {
                return NotFound();
            }

            var itnServRec = await _context.ItnServRec
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itnServRec == null)
            {
                return NotFound();
            }

            return View(itnServRec);
        }

        // GET: ItnServRecs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ItnServRecs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdOrdRec,IdOrdServ,Descricao,Valor,DataDeCriacao,UltimaModificacao")] ItnServRec itnServRec)
        {
            if (ModelState.IsValid)
            {
                _context.Add(itnServRec);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(itnServRec);
        }

        // GET: ItnServRecs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ItnServRec == null)
            {
                return NotFound();
            }

            var itnServRec = await _context.ItnServRec.FindAsync(id);
            if (itnServRec == null)
            {
                return NotFound();
            }
            return View(itnServRec);
        }

        // POST: ItnServRecs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdOrdRec,IdOrdServ,Descricao,Valor,DataDeCriacao,UltimaModificacao")] ItnServRec itnServRec)
        {
            if (id != itnServRec.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(itnServRec);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItnServRecExists(itnServRec.Id))
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
            return View(itnServRec);
        }

        // GET: ItnServRecs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ItnServRec == null)
            {
                return NotFound();
            }

            var itnServRec = await _context.ItnServRec
                .FirstOrDefaultAsync(m => m.Id == id);
            if (itnServRec == null)
            {
                return NotFound();
            }

            return View(itnServRec);
        }

        // POST: ItnServRecs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ItnServRec == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ItnServRec'  is null.");
            }
            var itnServRec = await _context.ItnServRec.FindAsync(id);
            if (itnServRec != null)
            {
                _context.ItnServRec.Remove(itnServRec);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItnServRecExists(int id)
        {
          return (_context.ItnServRec?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
