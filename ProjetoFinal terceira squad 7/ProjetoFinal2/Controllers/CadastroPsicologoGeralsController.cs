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
    public class CadastroPsicologoGeralsController : Controller
    {
        private readonly Context _context;

        public CadastroPsicologoGeralsController(Context context)
        {
            _context = context;
        }

        // GET: CadastroPsicologoGerals
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroPsicologoG.ToListAsync());
        }

        // GET: CadastroPsicologoGerals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPsicologoGeral = await _context.CadastroPsicologoG
                .FirstOrDefaultAsync(m => m.Id_PsicoG == id);
            if (cadastroPsicologoGeral == null)
            {
                return NotFound();
            }

            return View(cadastroPsicologoGeral);
        }

        // GET: CadastroPsicologoGerals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroPsicologoGerals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_PsicoG,Nome,Email,Telefone,Whatsapp")] CadastroPsicologoGeral cadastroPsicologoGeral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroPsicologoGeral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroPsicologoGeral);
        }

        // GET: CadastroPsicologoGerals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPsicologoGeral = await _context.CadastroPsicologoG.FindAsync(id);
            if (cadastroPsicologoGeral == null)
            {
                return NotFound();
            }
            return View(cadastroPsicologoGeral);
        }

        // POST: CadastroPsicologoGerals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_PsicoG,Nome,Email,Telefone,Whatsapp")] CadastroPsicologoGeral cadastroPsicologoGeral)
        {
            if (id != cadastroPsicologoGeral.Id_PsicoG)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroPsicologoGeral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroPsicologoGeralExists(cadastroPsicologoGeral.Id_PsicoG))
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
            return View(cadastroPsicologoGeral);
        }

        // GET: CadastroPsicologoGerals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPsicologoGeral = await _context.CadastroPsicologoG
                .FirstOrDefaultAsync(m => m.Id_PsicoG == id);
            if (cadastroPsicologoGeral == null)
            {
                return NotFound();
            }

            return View(cadastroPsicologoGeral);
        }

        // POST: CadastroPsicologoGerals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroPsicologoGeral = await _context.CadastroPsicologoG.FindAsync(id);
            _context.CadastroPsicologoG.Remove(cadastroPsicologoGeral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroPsicologoGeralExists(int id)
        {
            return _context.CadastroPsicologoG.Any(e => e.Id_PsicoG == id);
        }
    }
}
