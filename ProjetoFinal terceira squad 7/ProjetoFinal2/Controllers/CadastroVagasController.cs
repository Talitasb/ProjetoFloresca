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
    public class CadastroVagasController : Controller
    {
        private readonly Context _context;

        public CadastroVagasController(Context context)
        {
            _context = context;
        }

        // GET: CadastroVagas
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroVagas.ToListAsync());
        }

        // GET: CadastroVagas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVagas = await _context.CadastroVagas
                .FirstOrDefaultAsync(m => m.Id_Vagas == id);
            if (cadastroVagas == null)
            {
                return NotFound();
            }

            return View(cadastroVagas);
        }

        // GET: CadastroVagas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroVagas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Vagas,Nome,Email,Telefone,Whatsapp")] CadastroVagas cadastroVagas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroVagas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroVagas);
        }

        // GET: CadastroVagas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVagas = await _context.CadastroVagas.FindAsync(id);
            if (cadastroVagas == null)
            {
                return NotFound();
            }
            return View(cadastroVagas);
        }

        // POST: CadastroVagas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Vagas,Nome,Email,Telefone,Whatsapp")] CadastroVagas cadastroVagas)
        {
            if (id != cadastroVagas.Id_Vagas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroVagas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroVagasExists(cadastroVagas.Id_Vagas))
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
            return View(cadastroVagas);
        }

        // GET: CadastroVagas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVagas = await _context.CadastroVagas
                .FirstOrDefaultAsync(m => m.Id_Vagas == id);
            if (cadastroVagas == null)
            {
                return NotFound();
            }

            return View(cadastroVagas);
        }

        // POST: CadastroVagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroVagas = await _context.CadastroVagas.FindAsync(id);
            _context.CadastroVagas.Remove(cadastroVagas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroVagasExists(int id)
        {
            return _context.CadastroVagas.Any(e => e.Id_Vagas == id);
        }
    }
}
