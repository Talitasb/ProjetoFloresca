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
    public class CadastroJuridicoesController : Controller
    {
        private readonly Context _context;

        public CadastroJuridicoesController(Context context)
        {
            _context = context;
        }

        // GET: CadastroJuridicoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroJuridico.ToListAsync());
        }

        // GET: CadastroJuridicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroJuridico = await _context.CadastroJuridico
                .FirstOrDefaultAsync(m => m.Id_Juridico == id);
            if (cadastroJuridico == null)
            {
                return NotFound();
            }

            return View(cadastroJuridico);
        }

        // GET: CadastroJuridicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroJuridicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Juridico,Nome,Email,Telefone,Whatsapp")] CadastroJuridico cadastroJuridico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroJuridico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroJuridico);
        }

        // GET: CadastroJuridicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroJuridico = await _context.CadastroJuridico.FindAsync(id);
            if (cadastroJuridico == null)
            {
                return NotFound();
            }
            return View(cadastroJuridico);
        }

        // POST: CadastroJuridicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Juridico,Nome,Email,Telefone,Whatsapp")] CadastroJuridico cadastroJuridico)
        {
            if (id != cadastroJuridico.Id_Juridico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroJuridico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroJuridicoExists(cadastroJuridico.Id_Juridico))
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
            return View(cadastroJuridico);
        }

        // GET: CadastroJuridicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroJuridico = await _context.CadastroJuridico
                .FirstOrDefaultAsync(m => m.Id_Juridico == id);
            if (cadastroJuridico == null)
            {
                return NotFound();
            }

            return View(cadastroJuridico);
        }

        // POST: CadastroJuridicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroJuridico = await _context.CadastroJuridico.FindAsync(id);
            _context.CadastroJuridico.Remove(cadastroJuridico);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroJuridicoExists(int id)
        {
            return _context.CadastroJuridico.Any(e => e.Id_Juridico == id);
        }
    }
}
