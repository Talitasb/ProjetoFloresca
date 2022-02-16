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
    public class CadastroPessoaGeralsController : Controller
    {
        private readonly Context _context;

        public CadastroPessoaGeralsController(Context context)
        {
            _context = context;
        }

        // GET: CadastroPessoaGerals
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroPessoaG.ToListAsync());
        }

        // GET: CadastroPessoaGerals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPessoaGeral = await _context.CadastroPessoaG
                .FirstOrDefaultAsync(m => m.Id_Geral == id);
            if (cadastroPessoaGeral == null)
            {
                return NotFound();
            }

            return View(cadastroPessoaGeral);
        }

        // GET: CadastroPessoaGerals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroPessoaGerals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Geral,Email,Assunto,Mensagem")] CadastroPessoaGeral cadastroPessoaGeral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroPessoaGeral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroPessoaGeral);
        }

        // GET: CadastroPessoaGerals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPessoaGeral = await _context.CadastroPessoaG.FindAsync(id);
            if (cadastroPessoaGeral == null)
            {
                return NotFound();
            }
            return View(cadastroPessoaGeral);
        }

        // POST: CadastroPessoaGerals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Geral,Email,Assunto,Mensagem")] CadastroPessoaGeral cadastroPessoaGeral)
        {
            if (id != cadastroPessoaGeral.Id_Geral)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroPessoaGeral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroPessoaGeralExists(cadastroPessoaGeral.Id_Geral))
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
            return View(cadastroPessoaGeral);
        }

        // GET: CadastroPessoaGerals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroPessoaGeral = await _context.CadastroPessoaG
                .FirstOrDefaultAsync(m => m.Id_Geral == id);
            if (cadastroPessoaGeral == null)
            {
                return NotFound();
            }

            return View(cadastroPessoaGeral);
        }

        // POST: CadastroPessoaGerals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroPessoaGeral = await _context.CadastroPessoaG.FindAsync(id);
            _context.CadastroPessoaG.Remove(cadastroPessoaGeral);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroPessoaGeralExists(int id)
        {
            return _context.CadastroPessoaG.Any(e => e.Id_Geral == id);
        }
    }
}
