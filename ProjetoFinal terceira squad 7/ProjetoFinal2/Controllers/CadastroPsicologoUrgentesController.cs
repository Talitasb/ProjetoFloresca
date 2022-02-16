using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal2.Models;

namespace ProjetoFinal2.Controllers
{
    public class CadastroPsicologoUrgentesController : Controller
    {
        private readonly Context _context;

        public CadastroPsicologoUrgentesController(Context context)
        {
            _context = context;
        }

        // GET: CadastroPsicologoUrgentes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroPsicologoU.ToListAsync());
        }

        // GET: CadastroPsicologoUrgentes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPsicologoUrgente = await _context.CadastroPsicologoU
                .FirstOrDefaultAsync(m => m.Id_PsicoU == id);
            if (cadastroPsicologoUrgente == null)
            {
                return NotFound();
            }

            return View(cadastroPsicologoUrgente);
        }

        // GET: CadastroPsicologoUrgentes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroPsicologoUrgentes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_PsicoU,Nome,Email,Telefone,Whatsapp")] CadastroPsicologoUrgente cadastroPsicologoUrgente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroPsicologoUrgente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroPsicologoUrgente);
        }

        // GET: CadastroPsicologoUrgentes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPsicologoUrgente = await _context.CadastroPsicologoU.FindAsync(id);
            if (cadastroPsicologoUrgente == null)
            {
                return NotFound();
            }
            return View(cadastroPsicologoUrgente);
        }

        // POST: CadastroPsicologoUrgentes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_PsicoU,Nome,Email,Telefone,Whatsapp")] CadastroPsicologoUrgente cadastroPsicologoUrgente)
        {
            if (id != cadastroPsicologoUrgente.Id_PsicoU)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroPsicologoUrgente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroPsicologoUrgenteExists(cadastroPsicologoUrgente.Id_PsicoU))
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
            return View(cadastroPsicologoUrgente);
        }

        // GET: CadastroPsicologoUrgentes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPsicologoUrgente = await _context.CadastroPsicologoU
                .FirstOrDefaultAsync(m => m.Id_PsicoU == id);
            if (cadastroPsicologoUrgente == null)
            {
                return NotFound();
            }

            return View(cadastroPsicologoUrgente);
        }

        // POST: CadastroPsicologoUrgentes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroPsicologoUrgente = await _context.CadastroPsicologoU.FindAsync(id);
            _context.CadastroPsicologoU.Remove(cadastroPsicologoUrgente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroPsicologoUrgenteExists(int id)
        {
            return _context.CadastroPsicologoU.Any(e => e.Id_PsicoU == id);
        }
    }
}
