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
    public class CadastroVoluntariosController : Controller
    {
        private readonly Context _context;

        public CadastroVoluntariosController(Context context)
        {
            _context = context;
        }

        // GET: CadastroVoluntarios
        public async Task<IActionResult> Index()
        {
            return View(await _context.CadastroVoluntario.ToListAsync());
        }

        // GET: CadastroVoluntarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVoluntario = await _context.CadastroVoluntario
                .FirstOrDefaultAsync(m => m.Id_Voluntario == id);
            if (cadastroVoluntario == null)
            {
                return NotFound();
            }

            return View(cadastroVoluntario);
        }

        // GET: CadastroVoluntarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroVoluntarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Voluntario,Nome,Sobrenome,Endereco,Cidade,Estado,CEP,Psicologia,Juridico,Geral")] CadastroVoluntario cadastroVoluntario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroVoluntario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroVoluntario);
        }

        // GET: CadastroVoluntarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVoluntario = await _context.CadastroVoluntario.FindAsync(id);
            if (cadastroVoluntario == null)
            {
                return NotFound();
            }
            return View(cadastroVoluntario);
        }

        // POST: CadastroVoluntarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Voluntario,Nome,Sobrenome,Endereco,Cidade,Estado,CEP,Psicologia,Juridico,Geral")] CadastroVoluntario cadastroVoluntario)
        {
            if (id != cadastroVoluntario.Id_Voluntario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroVoluntario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroVoluntarioExists(cadastroVoluntario.Id_Voluntario))
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
            return View(cadastroVoluntario);
        }

        // GET: CadastroVoluntarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cadastroVoluntario = await _context.CadastroVoluntario
                .FirstOrDefaultAsync(m => m.Id_Voluntario == id);
            if (cadastroVoluntario == null)
            {
                return NotFound();
            }

            return View(cadastroVoluntario);
        }

        // POST: CadastroVoluntarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cadastroVoluntario = await _context.CadastroVoluntario.FindAsync(id);
            _context.CadastroVoluntario.Remove(cadastroVoluntario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroVoluntarioExists(int id)
        {
            return _context.CadastroVoluntario.Any(e => e.Id_Voluntario == id);
        }
    }
}
